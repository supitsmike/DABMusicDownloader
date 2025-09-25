namespace DABMusicDownloader.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pnlSearch = new Panel();
            lblSearchResults = new Label();
            cmbSearchType = new ComboBox();
            txtSearchQuery = new TextBox();
            btnSearch = new Button();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            dgvSearchResults = new DataGridView();
            pnlDownload = new Panel();
            lblStatusMessage = new Label();
            prgDownload = new ProgressBar();
            btnDownloadSelected = new Button();
            lblStatusSplash = new Label();
            pnlSearch.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).BeginInit();
            pnlDownload.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(lblSearchResults);
            pnlSearch.Controls.Add(cmbSearchType);
            pnlSearch.Controls.Add(txtSearchQuery);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 24);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(784, 29);
            pnlSearch.TabIndex = 2;
            // 
            // lblSearchResults
            // 
            lblSearchResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSearchResults.Location = new Point(500, 3);
            lblSearchResults.Name = "lblSearchResults";
            lblSearchResults.Size = new Size(281, 23);
            lblSearchResults.TabIndex = 3;
            lblSearchResults.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbSearchType
            // 
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Items.AddRange(new object[] { "Track", "Album" });
            cmbSearchType.Location = new Point(434, 3);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(60, 23);
            cmbSearchType.TabIndex = 2;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Location = new Point(84, 3);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.Size = new Size(344, 23);
            txtSearchQuery.TabIndex = 1;
            txtSearchQuery.KeyDown += txtSearchQuery_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(3, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(784, 24);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // dgvSearchResults
            // 
            dgvSearchResults.AllowUserToAddRows = false;
            dgvSearchResults.AllowUserToDeleteRows = false;
            dgvSearchResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSearchResults.BackgroundColor = SystemColors.Control;
            dgvSearchResults.BorderStyle = BorderStyle.None;
            dgvSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearchResults.Location = new Point(0, 53);
            dgvSearchResults.MultiSelect = false;
            dgvSearchResults.Name = "dgvSearchResults";
            dgvSearchResults.ReadOnly = true;
            dgvSearchResults.RowHeadersVisible = false;
            dgvSearchResults.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvSearchResults.RowTemplate.Height = 100;
            dgvSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSearchResults.Size = new Size(784, 379);
            dgvSearchResults.TabIndex = 4;
            dgvSearchResults.Scroll += dgvSearchResults_Scroll;
            // 
            // pnlDownload
            // 
            pnlDownload.Controls.Add(lblStatusMessage);
            pnlDownload.Controls.Add(prgDownload);
            pnlDownload.Controls.Add(btnDownloadSelected);
            pnlDownload.Dock = DockStyle.Bottom;
            pnlDownload.Location = new Point(0, 432);
            pnlDownload.Name = "pnlDownload";
            pnlDownload.Size = new Size(784, 29);
            pnlDownload.TabIndex = 5;
            // 
            // lblStatusMessage
            // 
            lblStatusMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatusMessage.Location = new Point(3, 3);
            lblStatusMessage.Name = "lblStatusMessage";
            lblStatusMessage.Size = new Size(125, 23);
            lblStatusMessage.TabIndex = 4;
            lblStatusMessage.Text = "Ready";
            lblStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // prgDownload
            // 
            prgDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            prgDownload.Location = new Point(134, 3);
            prgDownload.Name = "prgDownload";
            prgDownload.Size = new Size(521, 23);
            prgDownload.TabIndex = 1;
            // 
            // btnDownloadSelected
            // 
            btnDownloadSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDownloadSelected.Location = new Point(661, 3);
            btnDownloadSelected.Name = "btnDownloadSelected";
            btnDownloadSelected.Size = new Size(120, 23);
            btnDownloadSelected.TabIndex = 0;
            btnDownloadSelected.Text = "Download Selected";
            btnDownloadSelected.UseVisualStyleBackColor = true;
            btnDownloadSelected.Click += btnDownloadSelected_Click;
            // 
            // lblStatusSplash
            // 
            lblStatusSplash.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatusSplash.Location = new Point(0, 53);
            lblStatusSplash.Name = "lblStatusSplash";
            lblStatusSplash.Size = new Size(784, 379);
            lblStatusSplash.TabIndex = 0;
            lblStatusSplash.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusSplash.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(lblStatusSplash);
            Controls.Add(pnlDownload);
            Controls.Add(dgvSearchResults);
            Controls.Add(pnlSearch);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(800, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearchResults).EndInit();
            pnlDownload.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlSearch;
        private ComboBox cmbSearchType;
        private TextBox txtSearchQuery;
        private Button btnSearch;
        private Label lblSearchResults;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private DataGridView dgvSearchResults;
        private Panel pnlDownload;
        private ProgressBar prgDownload;
        private Button btnDownloadSelected;
        private Label lblStatusMessage;
        private Label lblStatusSplash;
    }
}
