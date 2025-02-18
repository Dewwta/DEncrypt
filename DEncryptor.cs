namespace DEncrypt
{
    public partial class DEncryptor : Form
    {
        #region - Signature -
        private static readonly byte[] AppSignature = new Guid("3d9744f9-ca2a-44ba-957e-a05ac696bd6b").ToByteArray();
        private const string SignaturePosition = "Encrypted with doota <3";

        
        #endregion

        #region - Runtime Vars -

        FileInfo currentFile;

        #endregion

        #region - Form Constructor -

        public DEncryptor()
        {
            InitializeComponent();
            currentFile = null;
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
                        MessageBox.Show("File loaded Successfully!");

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


        
    }
}
