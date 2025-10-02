namespace QobuzMusicDownloader.Controls
{
    partial class ItemCard
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
            components = new System.ComponentModel.Container();
            lblItemTitle = new ScrollableLabel();
            lblArtistName = new ScrollableLabel();
            lblExplicit = new Label();
            pnlAlbumCover = new Panel();
            lblAlbumTitle = new ScrollableLabel();
            toolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // lblItemTitle
            // 
            lblItemTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblItemTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItemTitle.ForeColor = SystemColors.ControlText;
            lblItemTitle.Location = new Point(19, 202);
            lblItemTitle.Name = "lblItemTitle";
            lblItemTitle.Size = new Size(181, 15);
            lblItemTitle.TabIndex = 1;
            lblItemTitle.Text = "Item Title";
            lblItemTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblItemTitle.UseMnemonic = false;
            lblItemTitle.Click += ItemCard_Click;
            lblItemTitle.DoubleClick += ItemCard_DoubleClick;
            // 
            // lblArtistName
            // 
            lblArtistName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblArtistName.ForeColor = SystemColors.GrayText;
            lblArtistName.Location = new Point(0, 220);
            lblArtistName.Name = "lblArtistName";
            lblArtistName.Size = new Size(200, 15);
            lblArtistName.TabIndex = 2;
            lblArtistName.Text = "Artist Name";
            lblArtistName.TextAlign = ContentAlignment.MiddleLeft;
            lblArtistName.UseMnemonic = false;
            lblArtistName.Click += ItemCard_Click;
            lblArtistName.DoubleClick += ItemCard_DoubleClick;
            // 
            // lblExplicit
            // 
            lblExplicit.BackColor = SystemColors.ControlText;
            lblExplicit.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblExplicit.ForeColor = SystemColors.Control;
            lblExplicit.Location = new Point(2, 202);
            lblExplicit.Name = "lblExplicit";
            lblExplicit.Size = new Size(15, 15);
            lblExplicit.TabIndex = 4;
            lblExplicit.Text = "E";
            lblExplicit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAlbumCover
            // 
            pnlAlbumCover.Location = new Point(0, 0);
            pnlAlbumCover.Name = "pnlAlbumCover";
            pnlAlbumCover.Size = new Size(200, 200);
            pnlAlbumCover.TabIndex = 5;
            pnlAlbumCover.Paint += pnlAlbumCover_Paint;
            pnlAlbumCover.MouseEnter += pnlAlbumCover_MouseEnter;
            pnlAlbumCover.MouseLeave += pnlAlbumCover_MouseLeave;
            // 
            // lblAlbumTitle
            // 
            lblAlbumTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAlbumTitle.ForeColor = SystemColors.GrayText;
            lblAlbumTitle.Location = new Point(0, 238);
            lblAlbumTitle.Name = "lblAlbumTitle";
            lblAlbumTitle.Size = new Size(200, 15);
            lblAlbumTitle.TabIndex = 6;
            lblAlbumTitle.Text = "Album Title";
            lblAlbumTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblAlbumTitle.UseMnemonic = false;
            // 
            // ItemCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlAlbumCover);
            Controls.Add(lblExplicit);
            Controls.Add(lblItemTitle);
            Controls.Add(lblArtistName);
            Controls.Add(lblAlbumTitle);
            Margin = new Padding(10);
            Name = "ItemCard";
            Size = new Size(200, 255);
            Click += ItemCard_Click;
            DoubleClick += ItemCard_DoubleClick;
            ResumeLayout(false);
        }

        #endregion
        private ScrollableLabel lblItemTitle;
        private ScrollableLabel lblArtistName;
        private Label lblExplicit;
        private Panel pnlAlbumCover;
        private ScrollableLabel lblAlbumTitle;
        private ToolTip toolTip;
    }
}
