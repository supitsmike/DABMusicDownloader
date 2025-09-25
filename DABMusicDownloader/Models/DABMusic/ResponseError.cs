using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic
{
    public class ResponseError
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
