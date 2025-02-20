using DEncrypt.Core;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace DEncrypt
{
    public partial class DEncryptor : Form
    {
        #region - Signature -
        private static readonly byte[] AppSignature = new Guid("3d9744f9-ca2a-44ba-957e-a05ac696bd6b").ToByteArray();
        private const string SignaturePosition = "Encrypted with doota <3";
        private readonly Guid AppGuid = Guid.Parse("3d9744f9-ca2a-44ba-957e-a05ac696bd6b");
        public static DEncryptor Instance { get; private set; }
        private static bool isFileOpen = false;
        private bool doesPwMatch = false;
       
        private string fileToLoad = null;

        private string[] files_Opened;

        public int _progress;
        
        #endregion

        #region - Runtime Vars -

        public static FileInfo currentFile;
        public static bool isDecrypting;
        public static bool isEncrypting;
        #endregion

        #region - Form Constructor -

        public DEncryptor(string[] args)
        {
            InitializeComponent();
            currentFile = null;
            Instance = this;

            

            lsFilesOpened.Items.Clear();
            btnEncrypt.Enabled = false;
            btnDecrypt.Enabled = false;
            inpPassword.ReadOnly = true;
            inpPasswordConfirm.ReadOnly = true;
            inpPasswordDecrypt.ReadOnly = true;

            string exePath = Directory.GetCurrentDirectory();
            this.Text = "DEncryptor";
            // MessageBox.Show("Before file constructor");
            this.Icon = new Icon(Path.Combine(exePath, "Images/DEncrypt_Icon.ico"));
            this.MaximizeBox = false;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);

            
            
            if (args.Length > 0 && File.Exists(args[0]) && args[0].EndsWith(".dew"))
            {
                fileToLoad = args[0];
                // MessageBox.Show("constructor if loaded");
            }
        }

        #endregion

        #region - Helpers -

        public void Log(string msg)
        {

            AppendColoredText(" " + msg + "\n", Color.LimeGreen);
        }
        public void LogWarning(string msg)
        {
            AppendColoredText(" " + msg + "\n", Color.Yellow);

        }

        public void LogError(string msg)
        {
            AppendColoredText(" " + msg + "\n", Color.Red);

        }

        

        

        private void AppendColoredText(string text, Color color)
        {
            if (tbxLogs.InvokeRequired)
            {

                tbxLogs.Invoke(new Action(() => {
                    tbxLogs.SelectionStart = tbxLogs.TextLength;
                    tbxLogs.SelectionLength = 0;
                    tbxLogs.SelectionColor = color;
                    tbxLogs.AppendText(text);
                    tbxLogs.SelectionColor = tbxLogs.ForeColor;
                }));
                
            }
            else
            {
                tbxLogs.SelectionStart = tbxLogs.TextLength;
                tbxLogs.SelectionLength = 0;
                tbxLogs.SelectionColor = color;
                tbxLogs.AppendText(text);
                tbxLogs.SelectionColor = tbxLogs.ForeColor;
            }

            
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            // Get dropped files
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                string filePath = files[0];
                LoadFile(filePath);

            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // MessageBox.Show("OnShown Called");


            if (fileToLoad != null)
            {
                // MessageBox.Show("OnShown If caught");
                LoadFile(fileToLoad);
                UpdateUI();
            }
        }

        public void AddBarProgress(int _progress)
        {
            if (pgbProgress.InvokeRequired)
            {
                pgbProgress.Invoke(new Action(() => pgbProgress.Value += _progress));
            }
            else
            {
                pgbProgress.Value += _progress;
            }
        }

        public void SetBarProgress(int _progress)
        {
            if (pgbProgress.InvokeRequired)
            {
                pgbProgress.Invoke(new Action(() => pgbProgress.Value = _progress));
            }
            else
            {
                pgbProgress.Value = _progress;
            }
        }

        // used for loading a file, this is a seperate method then Open File Button.
        public void LoadFile(string _filePath)
        {
            try
            {
                Log($"Loading file: {Path.GetFileName(_filePath)}");
                Log($"Location: {_filePath}");
                if (isFileOpen)
                {
                    var result = MessageBox.Show("Do you want to load a new file?",
                        "Load New File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                currentFile = new FileInfo(_filePath);
                UpdateUI();
                Log("File loaded.");
                isFileOpen = true;
                AddBarProgress(100);

                pgbProgress.Value = 0;
                btnEncrypt.Enabled = true;
                btnDecrypt.Enabled = true;
                inpPassword.ReadOnly = false;
                inpPasswordConfirm.ReadOnly = false;
                inpPasswordDecrypt.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}");

            }
        }

        // When message is received from the new window, it invokes the load file method with the message contents.
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x004A) // WM_COPYDATA
            {

                COPYDATASTRUCT cds = (COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(COPYDATASTRUCT));
                if (cds.cbData > 0)
                {
                    byte[] bytes = new byte[cds.cbData - 1];
                    Marshal.Copy(cds.lpData, bytes, 0, bytes.Length);
                    string filePath = System.Text.Encoding.Unicode.GetString(bytes);

                    Log("WndProc recieved file, reloading...");
                    this.Invoke(new Action(() =>
                    {
                        LoadFile(filePath);

                    }));
                }
            }
            base.WndProc(ref m);
        }

        /* This struct is used to copy data from one process to another,
         * when you open a second .dew file, it will open another window.
         * This allows the new instance to kill itself, but not before messaging
         * the original instance with the new data. 
        */
       
        [StructLayout(LayoutKind.Sequential)]
        private struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
        #endregion

        #region - File Helpers -

        private async void AddFileToArr()
        {

        }

        #endregion

        #region - Button Handlers -
        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                pgbProgress.Value = 0;
                ofd.Title = "Select a File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    try
                    {
                        FileInfo fi = new FileInfo(ofd.FileName);

                        currentFile = fi;
                        await UpdateUIAsync(currentFile);
                        AddBarProgress(100);
                        isFileOpen = true;



                        btnEncrypt.Enabled = true;
                        btnDecrypt.Enabled = true;
                        inpPassword.ReadOnly = false;
                        inpPasswordConfirm.ReadOnly = false;
                        inpPasswordDecrypt.ReadOnly = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}");
                        return;

                    }



                }


            }
        }

        #endregion

        #region - UI Helpers -
        private async Task UpdateUIAsync(FileInfo _fi)
        {
            string fileName = currentFile.Name;
            string trimmed = Path.GetFileName(fileName);

            lblFileInUse.Text = $"File: {fileName}";

        }

        private void UpdateUI()
        {
            string fileName = currentFile.Name;
            string trimmed = Path.GetFileName(fileName);

            lblFileInUse.Text = $"File: {fileName}";
        }


        #endregion

        #region - Encrypt/Decrypt -

        private async void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                

                
                MessageBox.Show("Remember to use a password you can remember! if you lose the password, it cannot be reversed.\nNote: The original file will still exist.");
                if (string.IsNullOrEmpty(inpPassword.Text) && string.IsNullOrEmpty(inpPasswordConfirm.Text))
                {
                    MessageBox.Show("Please enter a password for the encryption.");
                    return;
                }

                if (!doesPwMatch)
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }
                
                string password = inpPassword.Text;
                string encryptDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Encrypted");

                // Ensure the directory exists
                Directory.CreateDirectory(encryptDir);
                
                // Create the output file path in the "Encrypted" folder

                string outputFile = Path.Combine(encryptDir, currentFile.Name + ".dew");
                
                Task.Run(async() => Encryptor.EncryptFile(currentFile.FullName, outputFile, password, AppGuid));
                
                
                inpPassword.Text = "";
                inpPasswordConfirm.Text = "";

                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error encrypting file: {ex.Message}");
            }
        }
        private async void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                

                
                if (!Encryptor.IsFileEncrypted(currentFile.FullName, AppGuid))
                {
                    MessageBox.Show("This file was not encrypted by this application.");
                    return;
                }

                if (string.IsNullOrEmpty(inpPasswordDecrypt.Text))
                {
                    MessageBox.Show("Please enter a password");
                    return;
                }
                
                string password = inpPasswordDecrypt.Text;
                string decryptDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Decrypted");

                // Ensure the directory exists
                Directory.CreateDirectory(decryptDir);
                
                // Remove the ".dew" extension to restore original file name
                string originalFileName = Path.GetFileNameWithoutExtension(currentFile.Name);
                string outputFile = Path.Combine(decryptDir, originalFileName);
                
                if (await Encryptor.DecryptFile(currentFile.FullName, outputFile, password, AppGuid))
                {
                    
                    MessageBox.Show($"File decrypted successfully!\nSaved to: {outputFile}");
                    
                    inpPasswordDecrypt.Text = "";
                    SetBarProgress(0);
                }
                else
                {
                    MessageBox.Show("Failed to decrypt file. Wrong password or corrupted file.");
                    SetBarProgress(0);
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decrypting file: {ex.Message}");
            }
        }

        #endregion

        #region - Password Check -
        private void inpPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            if (inpPasswordConfirm.Text == inpPassword.Text)
            {
                doesPwMatch = true;

                lblPasswordMatch.Text = $"Passwords match!";
                lblPasswordMatch.ForeColor = Color.LimeGreen;


            }
            else if (inpPasswordConfirm.Text == "" || inpPassword.Text == "")
            {
                doesPwMatch = false;
                lblPasswordMatch.Text = $"Passwords do not match.";
                lblPasswordMatch.ForeColor = Color.Red;
            }
            else
            {
                doesPwMatch = false;
                lblPasswordMatch.Text = $"Passwords do not match.";
                lblPasswordMatch.ForeColor = Color.Red;
            }
        }

        private void inpPassword_TextChanged(object sender, EventArgs e)
        {
            if (inpPasswordConfirm.Text == inpPassword.Text)
            {
                doesPwMatch = true;

                lblPasswordMatch.Text = $"Passwords match!";
                lblPasswordMatch.ForeColor = Color.LimeGreen;
            }
            else if (inpPasswordConfirm.Text == "" || inpPassword.Text == "")
            {
                doesPwMatch = false;
                lblPasswordMatch.Text = $"Passwords do not match.";
                lblPasswordMatch.ForeColor = Color.Red;
            }
            else
            {
                doesPwMatch = false;
                lblPasswordMatch.Text = $"Passwords do not match.";
                lblPasswordMatch.ForeColor = Color.Red;
            }
        }

        #endregion

        #region - Output Buttons -
        private void btnEncOutput_Click(object sender, EventArgs e)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = $"{exeDir}Encrypted";

            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("If you got this than you did something majorly wrong.");
                return;
            }
        }

        private void btnDecOutput_Click(object sender, EventArgs e)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = $"{exeDir}Decrypted";

            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("If you got this than you did something majorly wrong.");
                return;
            }
        }

        #endregion

    }
}
