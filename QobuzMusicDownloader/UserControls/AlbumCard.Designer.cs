using QobuzMusicDownloader.CustomControls;
using System.Reflection;

namespace QobuzMusicDownloader.UserControls
{
    partial class AlbumCard
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
            lblAlbumTitle = new ScrollableLabel();
            lblArtistName = new ScrollableLabel();
            lblExplicit = new Label();
            SuspendLayout();
            // 
            // lblAlbumTitle
            // 
            lblAlbumTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAlbumTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAlbumTitle.ForeColor = SystemColors.ControlText;
            lblAlbumTitle.Location = new Point(17, 201);
            lblAlbumTitle.Name = "lblAlbumTitle";
            lblAlbumTitle.Size = new Size(183, 15);
            lblAlbumTitle.TabIndex = 1;
            lblAlbumTitle.Text = "Album Title";
            lblAlbumTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblAlbumTitle.UseMnemonic = false;
            lblAlbumTitle.Click += AlbumCard_Click;
            lblAlbumTitle.DoubleClick += AlbumCard_DoubleClick;
            // 
            // lblArtistName
            // 
            lblArtistName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblArtistName.ForeColor = SystemColors.GrayText;
            lblArtistName.Location = new Point(0, 219);
            lblArtistName.Name = "lblArtistName";
            lblArtistName.Size = new Size(200, 15);
            lblArtistName.TabIndex = 2;
            lblArtistName.Text = "Artist Name";
            lblArtistName.TextAlign = ContentAlignment.MiddleLeft;
            lblArtistName.UseMnemonic = false;
            lblArtistName.Click += AlbumCard_Click;
            lblArtistName.DoubleClick += AlbumCard_DoubleClick;
            // 
            // lblExplicit
            // 
            lblExplicit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblExplicit.BackColor = SystemColors.ControlText;
            lblExplicit.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblExplicit.ForeColor = SystemColors.Control;
            lblExplicit.Location = new Point(0, 201);
            lblExplicit.Name = "lblExplicit";
            lblExplicit.Size = new Size(15, 15);
            lblExplicit.TabIndex = 4;
            lblExplicit.Text = "E";
            lblExplicit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AlbumCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblExplicit);
            Controls.Add(lblAlbumTitle);
            Controls.Add(lblArtistName);
            Margin = new Padding(10);
            Name = "AlbumCard";
            Size = new Size(200, 236);
            Click += AlbumCard_Click;
            DoubleClick += AlbumCard_DoubleClick;
            ResumeLayout(false);
        }

        #endregion
        private ScrollableLabel lblAlbumTitle;
        private ScrollableLabel lblArtistName;
        private Label lblExplicit;
    }
}
