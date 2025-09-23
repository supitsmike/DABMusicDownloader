using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Stream
{
    public class StreamResponse : ResponseError
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
