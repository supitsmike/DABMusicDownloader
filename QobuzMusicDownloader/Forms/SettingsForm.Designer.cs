namespace QobuzMusicDownloader.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBaseURL = new Label();
            txtBaseURL = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblConcurrentDownloads = new Label();
            nudConcurrentDownloads = new NumericUpDown();
            txtDownloadLocation = new TextBox();
            lblDownloadLocation = new Label();
            nudSearchPageLimit = new NumericUpDown();
            lblSearchPageLimit = new Label();
            cmbDownloadQuality = new ComboBox();
            lblDownloadQuality = new Label();
            chkDarkMode = new CheckBox();
            lblDarkMode = new Label();
            btnBrowse = new Button();
            ((System.ComponentModel.ISupportInitialize)nudConcurrentDownloads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSearchPageLimit).BeginInit();
            SuspendLayout();
            // 
            // lblBaseURL
            // 
            lblBaseURL.Location = new Point(12, 12);
            lblBaseURL.Name = "lblBaseURL";
            lblBaseURL.Size = new Size(132, 23);
            lblBaseURL.TabIndex = 0;
            lblBaseURL.Text = "Base URL:";
            lblBaseURL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBaseURL
            // 
            txtBaseURL.Location = new Point(150, 12);
            txtBaseURL.Name = "txtBaseURL";
            txtBaseURL.Size = new Size(175, 23);
            txtBaseURL.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.Location = new Point(171, 179);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.Location = new Point(90, 179);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblConcurrentDownloads
            // 
            lblConcurrentDownloads.Location = new Point(12, 129);
            lblConcurrentDownloads.Name = "lblConcurrentDownloads";
            lblConcurrentDownloads.Size = new Size(132, 23);
            lblConcurrentDownloads.TabIndex = 4;
            lblConcurrentDownloads.Text = "Concurrent Downloads:";
            lblConcurrentDownloads.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudConcurrentDownloads
            // 
            nudConcurrentDownloads.Location = new Point(150, 129);
            nudConcurrentDownloads.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudConcurrentDownloads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudConcurrentDownloads.Name = "nudConcurrentDownloads";
            nudConcurrentDownloads.Size = new Size(32, 23);
            nudConcurrentDownloads.TabIndex = 8;
            nudConcurrentDownloads.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // txtDownloadLocation
            // 
            txtDownloadLocation.Location = new Point(150, 71);
            txtDownloadLocation.Name = "txtDownloadLocation";
            txtDownloadLocation.ReadOnly = true;
            txtDownloadLocation.Size = new Size(148, 23);
            txtDownloadLocation.TabIndex = 10;
            // 
            // lblDownloadLocation
            // 
            lblDownloadLocation.Location = new Point(12, 71);
            lblDownloadLocation.Name = "lblDownloadLocation";
            lblDownloadLocation.Size = new Size(132, 23);
            lblDownloadLocation.TabIndex = 9;
            lblDownloadLocation.Text = "Download Location:";
            lblDownloadLocation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudSearchPageLimit
            // 
            nudSearchPageLimit.Location = new Point(150, 41);
            nudSearchPageLimit.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudSearchPageLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSearchPageLimit.Name = "nudSearchPageLimit";
            nudSearchPageLimit.Size = new Size(40, 23);
            nudSearchPageLimit.TabIndex = 12;
            nudSearchPageLimit.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblSearchPageLimit
            // 
            lblSearchPageLimit.Location = new Point(12, 41);
            lblSearchPageLimit.Name = "lblSearchPageLimit";
            lblSearchPageLimit.Size = new Size(132, 23);
            lblSearchPageLimit.TabIndex = 11;
            lblSearchPageLimit.Text = "Search Page Limit:";
            lblSearchPageLimit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbDownloadQuality
            // 
            cmbDownloadQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDownloadQuality.FormattingEnabled = true;
            cmbDownloadQuality.Location = new Point(150, 100);
            cmbDownloadQuality.Name = "cmbDownloadQuality";
            cmbDownloadQuality.Size = new Size(175, 23);
            cmbDownloadQuality.TabIndex = 13;
            // 
            // lblDownloadQuality
            // 
            lblDownloadQuality.Location = new Point(12, 100);
            lblDownloadQuality.Name = "lblDownloadQuality";
            lblDownloadQuality.Size = new Size(132, 23);
            lblDownloadQuality.TabIndex = 14;
            lblDownloadQuality.Text = "Download Quality:";
            lblDownloadQuality.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkDarkMode
            // 
            chkDarkMode.AutoSize = true;
            chkDarkMode.Location = new Point(150, 158);
            chkDarkMode.Name = "chkDarkMode";
            chkDarkMode.Size = new Size(15, 14);
            chkDarkMode.TabIndex = 15;
            chkDarkMode.UseVisualStyleBackColor = true;
            // 
            // lblDarkMode
            // 
            lblDarkMode.Location = new Point(12, 153);
            lblDarkMode.Name = "lblDarkMode";
            lblDarkMode.Size = new Size(132, 23);
            lblDarkMode.TabIndex = 16;
            lblDarkMode.Text = "Dark Mode:";
            lblDarkMode.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(301, 71);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(24, 23);
            btnBrowse.TabIndex = 17;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 214);
            Controls.Add(btnBrowse);
            Controls.Add(lblDarkMode);
            Controls.Add(chkDarkMode);
            Controls.Add(lblDownloadQuality);
            Controls.Add(cmbDownloadQuality);
            Controls.Add(nudSearchPageLimit);
            Controls.Add(lblSearchPageLimit);
            Controls.Add(txtDownloadLocation);
            Controls.Add(lblDownloadLocation);
            Controls.Add(nudConcurrentDownloads);
            Controls.Add(lblConcurrentDownloads);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtBaseURL);
            Controls.Add(lblBaseURL);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)nudConcurrentDownloads).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSearchPageLimit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBaseURL;
        private TextBox txtBaseURL;
        private Button btnSave;
        private Button btnCancel;
        private Label lblConcurrentDownloads;
        private NumericUpDown nudConcurrentDownloads;
        private TextBox txtDownloadLocation;
        private Label lblDownloadLocation;
        private NumericUpDown nudSearchPageLimit;
        private Label lblSearchPageLimit;
        private ComboBox cmbDownloadQuality;
        private Label lblDownloadQuality;
        private CheckBox chkDarkMode;
        private Label lblDarkMode;
        private Button btnBrowse;
    }
}