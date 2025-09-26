using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.Models.Artist
{
    public class ArtistImage
    {
        /// <summary>
        /// 50x50 pixel image
        /// </summary>
        [JsonPropertyName("small")]
        public string Small { get; set; } = string.Empty;

        /// <summary>
        /// 230x230 pixel image
        /// </summary>
        [JsonPropertyName("medium")]
        public string Medium { get; set; } = string.Empty;

        /// <summary>
        /// 500x500 pixel image
        /// </summary>
        [JsonPropertyName("large")]
        public string Large { get; set; } = string.Empty;

        /// <summary>
        /// 1000x1000 pixel image
        /// </summary>
        [JsonPropertyName("extralarge")]
        public string ExtraLarge { get; set; } = string.Empty;

        /// <summary>
        /// 1400x1400 pixel image
        /// </summary>
        [JsonPropertyName("mega")]
        public string Mega { get; set; } = string.Empty;
    }
}
