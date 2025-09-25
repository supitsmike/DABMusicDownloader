using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Responses
{
    public class DownloadResponse : ApiResponse<DownloadData>;

    public class DownloadData
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
