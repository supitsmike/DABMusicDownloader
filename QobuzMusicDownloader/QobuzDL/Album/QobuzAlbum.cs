using System.Text.Json.Serialization;
using QobuzMusicDownloader.QobuzDL.Artist;

namespace QobuzMusicDownloader.QobuzDL.Album
{
    public class QobuzAlbum
    {
        /// <summary>
        /// Unique string identifier for the album
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Qobuz internal numeric ID
        /// </summary>
        [JsonPropertyName("qobuz_id")]
        public int QobuzId { get; set; }

        /// <summary>
        /// Album title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Album version/edition (e.g., "Deluxe Edition", "Remastered")
        /// </summary>
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Primary artist information
        /// </summary>
        [JsonPropertyName("artist")]
        public QobuzArtist Artist { get; set; } = new();

        /// <summary>
        /// All artists involved in the album with their roles
        /// </summary>
        [JsonPropertyName("artists")]
        public List<AlbumArtist> Artists { get; set; } = [];

        /// <summary>
        /// Unix timestamp of release date
        /// </summary>
        [JsonPropertyName("released_at")]
        public long ReleasedAt { get; set; }

        /// <summary>
        /// Original release date in YYYY-MM-DD format
        /// </summary>
        [JsonPropertyName("release_date_original")]
        public string ReleaseDateOriginal { get; set; } = string.Empty;

        /// <summary>
        /// Total duration in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Number of tracks in the album
        /// </summary>
        [JsonPropertyName("tracks_count")]
        public int TracksCount { get; set; }

        /// <summary>
        /// Album genre information
        /// </summary>
        [JsonPropertyName("genre")]
        public QobuzGenre Genre { get; set; } = new();

        /// <summary>
        /// Record label information
        /// </summary>
        [JsonPropertyName("label")]
        public QobuzLabel Label { get; set; } = new();

        /// <summary>
        /// Whether album is available in Hi-Res quality
        /// </summary>
        [JsonPropertyName("hires")]
        public bool HiRes { get; set; }

        /// <summary>
        /// Whether album is available for streaming
        /// </summary>
        [JsonPropertyName("streamable")]
        public bool Streamable { get; set; }

        /// <summary>
        /// Maximum bit depth available (e.g., 16, 24)
        /// </summary>
        [JsonPropertyName("maximum_bit_depth")]
        public int MaximumBitDepth { get; set; }

        /// <summary>
        /// Maximum sampling rate in kHz (e.g., 44.1, 96, 192)
        /// </summary>
        [JsonPropertyName("maximum_sampling_rate")]
        public decimal MaximumSamplingRate { get; set; }

        /// <summary>
        /// Whether album has explicit content warning
        /// </summary>
        [JsonPropertyName("parental_warning")]
        public bool ParentalWarning { get; set; }

        /// <summary>
        /// Universal Product Code
        /// </summary>
        [JsonPropertyName("upc")]
        public string Upc { get; set; } = string.Empty;

        /// <summary>
        /// Album artwork in various sizes
        /// </summary>
        [JsonPropertyName("image")]
        public AlbumImage Image { get; set; } = new();
    }
}
