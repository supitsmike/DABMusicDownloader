using QobuzMusicDownloader.Models;
using QobuzMusicDownloader.Properties;

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
            nudSearchResultLimit.Value = Settings.Default.SearchResultLimit;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.BaseURL = txtBaseURL.Text;
            Settings.Default.DownloadLocation = txtDownloadLocation.Text;
            Settings.Default.DownloadQuality = Convert.ToInt32(cmbDownloadQuality.SelectedValue);
            Settings.Default.ConcurrentDownloads = Convert.ToInt32(nudConcurrentDownloads.Value);
            Settings.Default.SearchResultLimit = Convert.ToInt32(nudSearchResultLimit.Value);
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        private void InitializeDownloadQuality()
        {
            cmbDownloadQuality.DataSource = new List<ComboBoxDataSource>
            {
                new()
                {
                    DisplayMember = "Hi-Res (up to 24-bit/192kHz)",
                    ValueMember = Convert.ToInt32(AudioQuality.HiRes)
                },
                new()
                {
                    DisplayMember = "FLAC Lossless",
                    ValueMember = Convert.ToInt32(AudioQuality.Lossless)
                },
                new()
                {
                    DisplayMember = "CD Quality (16-bit/44.1kHz)",
                    ValueMember = Convert.ToInt32(AudioQuality.CdQuality)
                },
                new()
                {
                    DisplayMember = "MP3 320kbps",
                    ValueMember = Convert.ToInt32(AudioQuality.High)
                }
            };

            cmbDownloadQuality.DisplayMember = nameof(ComboBoxDataSource.DisplayMember);
            cmbDownloadQuality.ValueMember = nameof(ComboBoxDataSource.ValueMember);
        }

        private class ComboBoxDataSource
        {
            public string DisplayMember { get; set; }
            public object ValueMember { get; set; }
        }

        private void txtDownloadLocation_Click(object sender, EventArgs e)
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

        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    using var folderDialog = new FolderBrowserDialog
        //    {
        //        Description = "Select Download Location",
        //        SelectedPath = txtDownloadLocation.Text,
        //        ShowNewFolderButton = true
        //    };
        //    if (folderDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        txtDownloadLocation.Text = folderDialog.SelectedPath;
        //    }
        //}
    }
}
