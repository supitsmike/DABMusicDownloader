using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Discography
{
    public class Image
    {
        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }

        [JsonPropertyName("extralarge")]
        public string Extralarge { get; set; }

        [JsonPropertyName("mega")]
        public string Mega { get; set; }
    }
}
