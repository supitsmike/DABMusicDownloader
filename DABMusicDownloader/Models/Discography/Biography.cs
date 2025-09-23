using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Discography
{
    public class Biography
    {
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
