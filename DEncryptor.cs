using DEncrypt.Core;

namespace DEncrypt
{
    public partial class DEncryptor : Form
    {
        #region - Signature -
        private static readonly byte[] AppSignature = new Guid("3d9744f9-ca2a-44ba-957e-a05ac696bd6b").ToByteArray();
        private const string SignaturePosition = "Encrypted with doota <3";
        private readonly Guid AppGuid = Guid.Parse("3d9744f9-ca2a-44ba-957e-a05ac696bd6b");
        public static DEncryptor Instance { get; private set; }
        private bool isFileOpen = false;
        private bool doesPwMatch = false;


        #endregion

        #region - Runtime Vars -

        FileInfo currentFile;

        #endregion

        #region - Form Constructor -

        public DEncryptor()
        {
            InitializeComponent();
            currentFile = null;
            Instance = this;

            btnEncrypt.Enabled = false;
            btnDecrypt.Enabled = false;
            inpPassword.ReadOnly = true;
            inpPasswordConfirm.ReadOnly = true;
            inpPasswordDecrypt.ReadOnly = true;


            
        }

        #endregion

        #region - Helpers -

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

        #endregion

        #region - Button Handlers -
        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    try
                    {
                        FileInfo fi = new FileInfo(ofd.FileName);

                        currentFile = fi;
                        UpdateUI(currentFile);
                        
                        isFileOpen = true;
                        AddBarProgress(100);
                        MessageBox.Show("File loaded Successfully!");
                        pgbProgress.Value = 0;
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
        private async Task UpdateUI(FileInfo _fi)
        {
            string fileName = _fi.Name;
            string trimmed = Path.GetFileName(fileName);

            lblFileInUse.Text = $"File: {fileName}";

        }


        #endregion

        #region - Encrypt/Decrypt -

        private void btnEncrypt_Click(object sender, EventArgs e)
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
                AddBarProgress(25);
                string password = inpPassword.Text;
                string encryptDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Encrypted");

                // Ensure the directory exists
                Directory.CreateDirectory(encryptDir);
                AddBarProgress(25);
                // Create the output file path in the "Encrypted" folder
                string trimmedName = currentFile.Name.Remove(currentFile.Name.Length - 4);
                string outputFile = Path.Combine(encryptDir, trimmedName + "_ENC" + ".dew");
                AddBarProgress(25);
                Encryptor.EncryptFile(currentFile.FullName, outputFile, password, AppGuid);
                MessageBox.Show($"File encrypted successfully!\nSaved to: {outputFile}");
                inpPassword.Text = "";
                inpPasswordConfirm.Text = "";
                AddBarProgress(25);
                pgbProgress.Value = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error encrypting file: {ex.Message}");
            }
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
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
                AddBarProgress(25);
                string password = inpPasswordDecrypt.Text;
                string decryptDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Decrypted");

                // Ensure the directory exists
                Directory.CreateDirectory(decryptDir);
                AddBarProgress(25);
                // Remove the ".dew" extension to restore original file name
                string originalFileName = Path.GetFileNameWithoutExtension(currentFile.Name);
                string outputFile = Path.Combine(decryptDir, originalFileName);
                AddBarProgress(25);
                if (Encryptor.DecryptFile(currentFile.FullName, outputFile, password, AppGuid))
                {
                    AddBarProgress(25);
                    MessageBox.Show($"File decrypted successfully!\nSaved to: {outputFile}");
                    pgbProgress.Value = 0;
                    inpPasswordDecrypt.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to decrypt file. Wrong password or corrupted file.");
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
            else
            {
                doesPwMatch = false;
                lblPasswordMatch.Text = $"Passwords do not match.";
                lblPasswordMatch.ForeColor = Color.Red;
            }
        }

        #endregion
    }
}
