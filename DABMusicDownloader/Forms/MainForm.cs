namespace DABMusicDownloader.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            cmbSearchType.SelectedIndex = 0;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }

        private void txtSearchQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            btnSearch.PerformClick();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvSearchResults_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvSearchResults.DisplayedRowCount(false) + dgvSearchResults.FirstDisplayedScrollingRowIndex >= dgvSearchResults.RowCount)
            {

            }
        }

        private void btnDownloadSelected_Click(object sender, EventArgs e)
        {

        }
    }
}
