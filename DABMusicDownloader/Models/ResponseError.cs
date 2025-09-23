using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models
{
    public class ResponseError
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
