using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.QobuzDL.Album
{
    public class AlbumImage
    {
        /// <summary>
        /// 230x230 pixel image
        /// </summary>
        [JsonPropertyName("small")]
        public string Small { get; set; } = string.Empty;

        /// <summary>
        /// 50x50 pixel image
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;

        /// <summary>
        /// 600x600 pixel image
        /// </summary>
        [JsonPropertyName("large")]
        public string Large { get; set; } = string.Empty;

        /// <summary>
        /// Back cover image, null if not available
        /// </summary>
        [JsonPropertyName("back")]
        public string Back { get; set; }
    }
}
