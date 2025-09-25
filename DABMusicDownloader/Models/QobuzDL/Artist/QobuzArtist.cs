using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Artist
{
    public class QobuzArtist
    {
        /// <summary>
        /// Unique identifier for the artist
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Artist display name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Total number of albums by this artist
        /// </summary>
        [JsonPropertyName("albums_count")]
        public int AlbumsCount { get; set; }

        /// <summary>
        /// Artist images in various sizes, null if no image available
        /// </summary>
        [JsonPropertyName("image")]
        public ArtistImage? Image { get; set; }
    }
}
