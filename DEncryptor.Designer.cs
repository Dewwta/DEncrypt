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
            lblPasswordMatch = new Label();
            btnEncrypt = new Button();
            lblPasswordConfirm = new Label();
            lblPassword = new Label();
            inpPasswordConfirm = new TextBox();
            pgbProgress = new ProgressBar();
            panel1 = new Panel();
            label1 = new Label();
            inpPasswordDecrypt = new TextBox();
            btnDecrypt = new Button();
            lblFileInUse = new Label();
            tbxLog = new TextBox();
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
            // lblPasswordMatch
            // 
            lblPasswordMatch.AutoSize = true;
            lblPasswordMatch.Font = new Font("Segoe UI", 14F);
            lblPasswordMatch.ForeColor = Color.Fuchsia;
            lblPasswordMatch.Location = new Point(13, 111);
            lblPasswordMatch.Name = "lblPasswordMatch";
            lblPasswordMatch.Size = new Size(213, 25);
            lblPasswordMatch.TabIndex = 7;
            lblPasswordMatch.Text = "Password Doesnt Match";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Font = new Font("Segoe UI", 15F);
            btnEncrypt.Location = new Point(13, 241);
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
            panel1.Controls.Add(label1);
            panel1.Controls.Add(inpPasswordDecrypt);
            panel1.Controls.Add(btnDecrypt);
            panel1.Location = new Point(355, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 296);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 9;
            label1.Text = "Password:";
            // 
            // inpPasswordDecrypt
            // 
            inpPasswordDecrypt.Font = new Font("Segoe UI", 15F);
            inpPasswordDecrypt.Location = new Point(101, 26);
            inpPasswordDecrypt.Name = "inpPasswordDecrypt";
            inpPasswordDecrypt.Size = new Size(200, 34);
            inpPasswordDecrypt.TabIndex = 8;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI", 15F);
            btnDecrypt.Location = new Point(12, 241);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(294, 40);
            btnDecrypt.TabIndex = 7;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
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
            // tbxLog
            // 
            tbxLog.BorderStyle = BorderStyle.FixedSingle;
            tbxLog.Location = new Point(355, 57);
            tbxLog.Multiline = true;
            tbxLog.Name = "tbxLog";
            tbxLog.ReadOnly = true;
            tbxLog.Size = new Size(326, 70);
            tbxLog.TabIndex = 10;
            // 
            // DEncryptor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 441);
            Controls.Add(tbxLog);
            Controls.Add(lblFileInUse);
            Controls.Add(panel1);
            Controls.Add(pgbProgress);
            Controls.Add(pnlMain);
            Controls.Add(btnOpenFile);
            Name = "DEncryptor";
            Text = "DEncryptor... By doota <3";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox tbxLog;
    }
}
