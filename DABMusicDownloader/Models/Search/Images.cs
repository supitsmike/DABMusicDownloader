using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Search
{
    public class Images
    {
        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }

        [JsonPropertyName("back")]
        public string Back { get; set; }
    }
}
