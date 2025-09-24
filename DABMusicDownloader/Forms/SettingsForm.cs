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
            nudSearchResultLimit.Value = Settings.Default.SearchResultLimit;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.BaseURL = txtBaseURL.Text;
            Settings.Default.DownloadLocation = txtDownloadLocation.Text;
            Settings.Default.ConcurrentDownloads = Convert.ToInt32(nudConcurrentDownloads.Value);
            Settings.Default.SearchResultLimit = Convert.ToInt32(nudSearchResultLimit.Value);
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
    }
}
