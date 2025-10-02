using QobuzMusicDownloader.Properties;
using QobuzMusicDownloader.QobuzDL.Core;

namespace QobuzMusicDownloader.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            InitializeDownloadQuality();

            txtBaseURL.Text = Settings.Default.BaseURL;
            txtDownloadLocation.Text = Settings.Default.DownloadLocation;
            cmbDownloadQuality.SelectedValue = Settings.Default.DownloadQuality;
            nudConcurrentDownloads.Value = Settings.Default.ConcurrentDownloads;
            nudSearchPageLimit.Value = Settings.Default.SearchPageLimit;
            chkDarkMode.Checked = Settings.Default.DarkMode;
        }

        private void InitializeDownloadQuality()
        {
            cmbDownloadQuality.DataSource = new List<ComboBoxDataSource>
            {
                new("Hi-Res (up to 24-bit/192kHz)", Convert.ToInt32(AudioQuality.HiRes)),
                new("FLAC Lossless", Convert.ToInt32(AudioQuality.Lossless)),
                new("CD Quality (16-bit/44.1kHz)", Convert.ToInt32(AudioQuality.CdQuality)),
                new("MP3 320kbps", Convert.ToInt32(AudioQuality.High))
            };

            cmbDownloadQuality.DisplayMember = nameof(ComboBoxDataSource.DisplayMember);
            cmbDownloadQuality.ValueMember = nameof(ComboBoxDataSource.ValueMember);
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.BaseURL = txtBaseURL.Text;
            Settings.Default.DownloadLocation = txtDownloadLocation.Text;
            Settings.Default.DownloadQuality = Convert.ToInt32(cmbDownloadQuality.SelectedValue);
            Settings.Default.ConcurrentDownloads = Convert.ToInt32(nudConcurrentDownloads.Value);
            Settings.Default.SearchPageLimit = Convert.ToInt32(nudSearchPageLimit.Value);
            Settings.Default.DarkMode = chkDarkMode.Checked;
            Settings.Default.Save();

            QobuzDL.QobuzDLAPI.BaseUrl = Settings.Default.BaseURL;

            DialogResult = DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog();
            folderDialog.Description = @"Select Download Location";
            folderDialog.SelectedPath = txtDownloadLocation.Text;
            folderDialog.ShowNewFolderButton = true;
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtDownloadLocation.Text = folderDialog.SelectedPath;
            }
        }

        private class ComboBoxDataSource(string displayMember, object valueMember)
        {
            public string DisplayMember { get; set; } = displayMember;
            public object ValueMember { get; set; } = valueMember;
        }
    }
}
