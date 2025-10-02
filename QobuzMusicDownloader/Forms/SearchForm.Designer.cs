using QobuzMusicDownloader.CustomControls;

namespace QobuzMusicDownloader.Forms
{
    partial class SearchForm
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
            flpSearchResults = new FlowLayoutPanel();
            btnSearch = new Button();
            txtSearchQuery = new TextBox();
            cmbSearchType = new ComboBox();
            btnSettings = new Button();
            SuspendLayout();
            // 
            // flpSearchResults
            // 
            flpSearchResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpSearchResults.AutoScroll = true;
            flpSearchResults.Location = new Point(0, 48);
            flpSearchResults.Name = "flpSearchResults";
            flpSearchResults.Size = new Size(897, 513);
            flpSearchResults.TabIndex = 0;
            flpSearchResults.Scroll += flpSearchResults_Scroll;
            flpSearchResults.MouseWheel += flpSearchResults_MouseWheel;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Font = new Font("Segoe UI", 12.5F);
            btnSearch.ForeColor = SystemColors.ControlText;
            btnSearch.Location = new Point(652, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchQuery.Font = new Font("Segoe UI", 12.5F);
            txtSearchQuery.Location = new Point(219, 12);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.PlaceholderText = "Search for anything...";
            txtSearchQuery.Size = new Size(427, 30);
            txtSearchQuery.TabIndex = 2;
            txtSearchQuery.TextChanged += txtSearchQuery_TextChanged;
            txtSearchQuery.KeyDown += txtSearchQuery_KeyDown;
            // 
            // cmbSearchType
            // 
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.Font = new Font("Segoe UI", 12F);
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Items.AddRange(new object[] { "Albums", "Tracks", "Atrists" });
            cmbSearchType.Location = new Point(133, 12);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(80, 29);
            cmbSearchType.TabIndex = 3;
            cmbSearchType.SelectedIndexChanged += cmbSearchType_SelectedIndexChanged;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.BackgroundImage = Properties.Resources.settings;
            btnSettings.BackgroundImageLayout = ImageLayout.Zoom;
            btnSettings.ForeColor = SystemColors.ControlText;
            btnSettings.Location = new Point(733, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(30, 30);
            btnSettings.TabIndex = 4;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 561);
            Controls.Add(btnSettings);
            Controls.Add(cmbSearchType);
            Controls.Add(txtSearchQuery);
            Controls.Add(btnSearch);
            Controls.Add(flpSearchResults);
            Name = "SearchForm";
            Text = "Search Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpSearchResults;
        private Button btnSearch;
        private TextBox txtSearchQuery;
        private ComboBox cmbSearchType;
        private Button btnSettings;
    }
}