namespace DABMusicDownloader.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            cmbSearchType.SelectedIndex = 0;
        }

        private void txtSearchQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            btnSearch.PerformClick();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }
    }
}
