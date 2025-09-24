namespace DABMusicDownloader.Forms
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
            nudSearchResultLimit = new NumericUpDown();
            lblSearchResultLimit = new Label();
            ((System.ComponentModel.ISupportInitialize)nudConcurrentDownloads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSearchResultLimit).BeginInit();
            SuspendLayout();
            // 
            // lblBaseURL
            // 
            lblBaseURL.AutoSize = true;
            lblBaseURL.Location = new Point(86, 15);
            lblBaseURL.Name = "lblBaseURL";
            lblBaseURL.Size = new Size(58, 15);
            lblBaseURL.TabIndex = 0;
            lblBaseURL.Text = "Base URL:";
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
            btnSave.Location = new Point(171, 128);
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
            btnCancel.Location = new Point(90, 128);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblConcurrentDownloads
            // 
            lblConcurrentDownloads.AutoSize = true;
            lblConcurrentDownloads.Location = new Point(12, 102);
            lblConcurrentDownloads.Name = "lblConcurrentDownloads";
            lblConcurrentDownloads.Size = new Size(132, 15);
            lblConcurrentDownloads.TabIndex = 4;
            lblConcurrentDownloads.Text = "Concurrent Downloads:";
            // 
            // nudConcurrentDownloads
            // 
            nudConcurrentDownloads.Location = new Point(150, 99);
            nudConcurrentDownloads.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudConcurrentDownloads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudConcurrentDownloads.Name = "nudConcurrentDownloads";
            nudConcurrentDownloads.Size = new Size(32, 23);
            nudConcurrentDownloads.TabIndex = 8;
            nudConcurrentDownloads.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // txtDownloadLocation
            // 
            txtDownloadLocation.Location = new Point(150, 70);
            txtDownloadLocation.Name = "txtDownloadLocation";
            txtDownloadLocation.Size = new Size(175, 23);
            txtDownloadLocation.TabIndex = 10;
            // 
            // lblDownloadLocation
            // 
            lblDownloadLocation.AutoSize = true;
            lblDownloadLocation.Location = new Point(31, 73);
            lblDownloadLocation.Name = "lblDownloadLocation";
            lblDownloadLocation.Size = new Size(113, 15);
            lblDownloadLocation.TabIndex = 9;
            lblDownloadLocation.Text = "Download Location:";
            // 
            // nudSearchResultLimit
            // 
            nudSearchResultLimit.Location = new Point(150, 41);
            nudSearchResultLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSearchResultLimit.Name = "nudSearchResultLimit";
            nudSearchResultLimit.Size = new Size(40, 23);
            nudSearchResultLimit.TabIndex = 12;
            nudSearchResultLimit.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblSearchResultLimit
            // 
            lblSearchResultLimit.AutoSize = true;
            lblSearchResultLimit.Location = new Point(34, 43);
            lblSearchResultLimit.Name = "lblSearchResultLimit";
            lblSearchResultLimit.Size = new Size(110, 15);
            lblSearchResultLimit.TabIndex = 11;
            lblSearchResultLimit.Text = "Search Result Limit:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 163);
            Controls.Add(nudSearchResultLimit);
            Controls.Add(lblSearchResultLimit);
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
            ((System.ComponentModel.ISupportInitialize)nudSearchResultLimit).EndInit();
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
        private NumericUpDown nudSearchResultLimit;
        private Label lblSearchResultLimit;
    }
}