using DABMusicDownloader.Properties;

namespace DABMusicDownloader.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtBaseURL.Text = Settings.Default.BaseURL;
            txtDownloadLocation.Text = Settings.Default.DownloadLocation;
            nudConcurrentDownloads.Value = Settings.Default.ConcurrentDownloads;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.BaseURL = txtBaseURL.Text;
            Settings.Default.DownloadLocation = txtDownloadLocation.Text;
            Settings.Default.ConcurrentDownloads = nudConcurrentDownloads.Value;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
