using QobuzMusicDownloader.CustomControls;

namespace QobuzMusicDownloader.UserControls
{
    partial class TrackCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTrackTitle = new ScrollableLabel();
            lblArtistName = new ScrollableLabel();
            lblExplicit = new Label();
            lblAlbumTitle = new ScrollableLabel();
            SuspendLayout();
            // 
            // lblTrackTitle
            // 
            lblTrackTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrackTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrackTitle.ForeColor = SystemColors.ControlText;
            lblTrackTitle.Location = new Point(17, 203);
            lblTrackTitle.Name = "lblTrackTitle";
            lblTrackTitle.Size = new Size(183, 15);
            lblTrackTitle.TabIndex = 1;
            lblTrackTitle.Text = "Track Title";
            lblTrackTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTrackTitle.UseMnemonic = false;
            lblTrackTitle.Click += TrackCard_Click;
            lblTrackTitle.DoubleClick += TrackCard_DoubleClick;
            // 
            // lblArtistName
            // 
            lblArtistName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblArtistName.ForeColor = SystemColors.GrayText;
            lblArtistName.Location = new Point(0, 221);
            lblArtistName.Name = "lblArtistName";
            lblArtistName.Size = new Size(200, 15);
            lblArtistName.TabIndex = 2;
            lblArtistName.Text = "Artist Name";
            lblArtistName.TextAlign = ContentAlignment.MiddleLeft;
            lblArtistName.UseMnemonic = false;
            lblArtistName.Click += TrackCard_Click;
            lblArtistName.DoubleClick += TrackCard_DoubleClick;
            // 
            // lblExplicit
            // 
            lblExplicit.BackColor = SystemColors.ControlText;
            lblExplicit.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblExplicit.ForeColor = SystemColors.Control;
            lblExplicit.Location = new Point(0, 203);
            lblExplicit.Name = "lblExplicit";
            lblExplicit.Size = new Size(15, 15);
            lblExplicit.TabIndex = 4;
            lblExplicit.Text = "E";
            lblExplicit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAlbumTitle
            // 
            lblAlbumTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAlbumTitle.ForeColor = SystemColors.GrayText;
            lblAlbumTitle.Location = new Point(0, 239);
            lblAlbumTitle.Name = "lblAlbumTitle";
            lblAlbumTitle.Size = new Size(200, 15);
            lblAlbumTitle.TabIndex = 5;
            lblAlbumTitle.Text = "Album Title";
            lblAlbumTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblAlbumTitle.UseMnemonic = false;
            // 
            // TrackCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAlbumTitle);
            Controls.Add(lblExplicit);
            Controls.Add(lblTrackTitle);
            Controls.Add(lblArtistName);
            Margin = new Padding(10);
            Name = "TrackCard";
            Size = new Size(200, 255);
            Click += TrackCard_Click;
            DoubleClick += TrackCard_DoubleClick;
            ResumeLayout(false);
        }

        #endregion
        private ScrollableLabel lblTrackTitle;
        private ScrollableLabel lblArtistName;
        private Label lblExplicit;
        private ScrollableLabel lblAlbumTitle;
    }
}
