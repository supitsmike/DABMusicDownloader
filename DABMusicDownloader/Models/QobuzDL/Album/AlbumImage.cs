using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Album
{
    public class AlbumImage
    {
        /// <summary>
        /// Small thumbnail image
        /// </summary>
        [JsonPropertyName("small")]
        public string Small { get; set; } = string.Empty;

        /// <summary>
        /// Standard thumbnail image
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;

        /// <summary>
        /// Large cover image
        /// </summary>
        [JsonPropertyName("large")]
        public string Large { get; set; } = string.Empty;

        /// <summary>
        /// Back cover image, null if not available
        /// </summary>
        [JsonPropertyName("back")]
        public string? Back { get; set; }
    }
}
