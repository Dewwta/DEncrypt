namespace DEncrypt
{
    partial class DEncryptor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpenFile = new Button();
            inpPassword = new TextBox();
            pnlMain = new Panel();
            inpPasswordDecrypt = new TextBox();
            label1 = new Label();
            btnDecrypt = new Button();
            lblPasswordMatch = new Label();
            btnEncrypt = new Button();
            lblPasswordConfirm = new Label();
            lblPassword = new Label();
            inpPasswordConfirm = new TextBox();
            pgbProgress = new ProgressBar();
            panel1 = new Panel();
            lsFilesOpened = new CheckedListBox();
            listView1 = new ListView();
            lblFileInUse = new Label();
            tbxLogs = new RichTextBox();
            btnEncOutput = new Button();
            btnDecOutput = new Button();
            pnlMain.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenFile
            // 
            btnOpenFile.Font = new Font("Segoe UI", 15F);
            btnOpenFile.Location = new Point(12, 12);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(150, 39);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "Open File";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // inpPassword
            // 
            inpPassword.Font = new Font("Segoe UI", 15F);
            inpPassword.Location = new Point(92, 19);
            inpPassword.Name = "inpPassword";
            inpPassword.Size = new Size(200, 34);
            inpPassword.TabIndex = 2;
            inpPassword.TextChanged += inpPassword_TextChanged;
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(inpPasswordDecrypt);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(btnDecrypt);
            pnlMain.Controls.Add(lblPasswordMatch);
            pnlMain.Controls.Add(btnEncrypt);
            pnlMain.Controls.Add(lblPasswordConfirm);
            pnlMain.Controls.Add(lblPassword);
            pnlMain.Controls.Add(inpPasswordConfirm);
            pnlMain.Controls.Add(inpPassword);
            pnlMain.Location = new Point(12, 133);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(326, 296);
            pnlMain.TabIndex = 3;
            // 
            // inpPasswordDecrypt
            // 
            inpPasswordDecrypt.Font = new Font("Segoe UI", 15F);
            inpPasswordDecrypt.Location = new Point(92, 197);
            inpPasswordDecrypt.Name = "inpPasswordDecrypt";
            inpPasswordDecrypt.Size = new Size(200, 34);
            inpPasswordDecrypt.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(13, 203);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 9;
            label1.Text = "Password:";
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI", 15F);
            btnDecrypt.Location = new Point(13, 250);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(294, 40);
            btnDecrypt.TabIndex = 7;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // lblPasswordMatch
            // 
            lblPasswordMatch.AutoSize = true;
            lblPasswordMatch.Font = new Font("Segoe UI", 14F);
            lblPasswordMatch.ForeColor = Color.Fuchsia;
            lblPasswordMatch.Location = new Point(13, 101);
            lblPasswordMatch.Name = "lblPasswordMatch";
            lblPasswordMatch.Size = new Size(213, 25);
            lblPasswordMatch.TabIndex = 7;
            lblPasswordMatch.Text = "Password Doesnt Match";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Font = new Font("Segoe UI", 15F);
            btnEncrypt.Location = new Point(13, 139);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(294, 40);
            btnEncrypt.TabIndex = 6;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // lblPasswordConfirm
            // 
            lblPasswordConfirm.AutoSize = true;
            lblPasswordConfirm.Font = new Font("Segoe UI", 12F);
            lblPasswordConfirm.Location = new Point(13, 65);
            lblPasswordConfirm.Name = "lblPasswordConfirm";
            lblPasswordConfirm.Size = new Size(70, 21);
            lblPasswordConfirm.TabIndex = 5;
            lblPasswordConfirm.Text = "Confirm:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(13, 23);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // inpPasswordConfirm
            // 
            inpPasswordConfirm.Font = new Font("Segoe UI", 15F);
            inpPasswordConfirm.Location = new Point(92, 59);
            inpPasswordConfirm.Name = "inpPasswordConfirm";
            inpPasswordConfirm.Size = new Size(200, 34);
            inpPasswordConfirm.TabIndex = 3;
            inpPasswordConfirm.TextChanged += inpPasswordConfirm_TextChanged;
            // 
            // pgbProgress
            // 
            pgbProgress.Location = new Point(178, 12);
            pgbProgress.Name = "pgbProgress";
            pgbProgress.Size = new Size(503, 39);
            pgbProgress.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lsFilesOpened);
            panel1.Controls.Add(listView1);
            panel1.Location = new Point(355, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 296);
            panel1.TabIndex = 8;
            // 
            // lsFilesOpened
            // 
            lsFilesOpened.BackColor = SystemColors.ControlDark;
            lsFilesOpened.BorderStyle = BorderStyle.None;
            lsFilesOpened.Font = new Font("Segoe UI", 12F);
            lsFilesOpened.FormattingEnabled = true;
            lsFilesOpened.Location = new Point(3, 3);
            lsFilesOpened.Name = "lsFilesOpened";
            lsFilesOpened.Size = new Size(320, 288);
            lsFilesOpened.TabIndex = 11;
            // 
            // listView1
            // 
            listView1.BackColor = Color.DarkGray;
            listView1.Location = new Point(-1, -1);
            listView1.Name = "listView1";
            listView1.Size = new Size(326, 296);
            listView1.TabIndex = 10;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lblFileInUse
            // 
            lblFileInUse.AutoSize = true;
            lblFileInUse.Font = new Font("Segoe UI", 15F);
            lblFileInUse.Location = new Point(12, 77);
            lblFileInUse.Name = "lblFileInUse";
            lblFileInUse.Size = new Size(164, 28);
            lblFileInUse.TabIndex = 9;
            lblFileInUse.Text = "File: Not Selected";
            // 
            // tbxLogs
            // 
            tbxLogs.BackColor = Color.FromArgb(64, 64, 64);
            tbxLogs.ForeColor = Color.White;
            tbxLogs.Location = new Point(685, 12);
            tbxLogs.Name = "tbxLogs";
            tbxLogs.Size = new Size(340, 417);
            tbxLogs.TabIndex = 10;
            tbxLogs.Text = "";
            // 
            // btnEncOutput
            // 
            btnEncOutput.Location = new Point(501, 57);
            btnEncOutput.Name = "btnEncOutput";
            btnEncOutput.Size = new Size(178, 30);
            btnEncOutput.TabIndex = 11;
            btnEncOutput.Text = "Encryption Output";
            btnEncOutput.UseVisualStyleBackColor = true;
            btnEncOutput.Click += btnEncOutput_Click;
            // 
            // btnDecOutput
            // 
            btnDecOutput.Location = new Point(501, 93);
            btnDecOutput.Name = "btnDecOutput";
            btnDecOutput.Size = new Size(178, 30);
            btnDecOutput.TabIndex = 12;
            btnDecOutput.Text = "Decryption Output";
            btnDecOutput.UseVisualStyleBackColor = true;
            btnDecOutput.Click += btnDecOutput_Click;
            // 
            // DEncryptor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1030, 436);
            Controls.Add(btnDecOutput);
            Controls.Add(btnEncOutput);
            Controls.Add(tbxLogs);
            Controls.Add(lblFileInUse);
            Controls.Add(panel1);
            Controls.Add(pgbProgress);
            Controls.Add(pnlMain);
            Controls.Add(btnOpenFile);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DEncryptor";
            Text = "DEncryptor... By doota <3";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnOpenFile;
        private TextBox inpPassword;
        private Panel pnlMain;
        private TextBox inpPasswordConfirm;
        private Label lblPasswordConfirm;
        private Label lblPassword;
        private Button btnEncrypt;
        private ProgressBar pgbProgress;
        private Panel panel1;
        private TextBox inpPasswordDecrypt;
        private Button btnDecrypt;
        private Label label1;
        private Label lblFileInUse;
        private Label lblPasswordMatch;
        private RichTextBox tbxLogs;
        private CheckedListBox lsFilesOpened;
        private ListView listView1;
        private Button btnEncOutput;
        private Button btnDecOutput;
    }
}
