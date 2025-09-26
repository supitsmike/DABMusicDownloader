using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.QobuzDL.Album
{
    public class QobuzLabel
    {
        /// <summary>
        /// Unique identifier for the record label
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Record label name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Number of albums from this label
        /// </summary>
        [JsonPropertyName("albums_count")]
        public int AlbumsCount { get; set; }
    }
}
