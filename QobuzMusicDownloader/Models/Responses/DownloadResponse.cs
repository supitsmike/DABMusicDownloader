using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.Models.Responses
{
    public class DownloadResponse : ApiResponse<DownloadData>;

    public class DownloadData
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
