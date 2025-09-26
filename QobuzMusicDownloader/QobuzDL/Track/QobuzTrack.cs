using System.Text.Json.Serialization;
using QobuzMusicDownloader.QobuzDL.Album;

namespace QobuzMusicDownloader.QobuzDL.Track
{
    public class QobuzTrack
    {
        /// <summary>
        /// Unique numeric identifier for the track
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Track title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Track version/remix information
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// Track number within the album/disc
        /// </summary>
        [JsonPropertyName("track_number")]
        public int TrackNumber { get; set; }

        /// <summary>
        /// Disc/media number (for multi-disc albums)
        /// </summary>
        [JsonPropertyName("media_number")]
        public int MediaNumber { get; set; }

        /// <summary>
        /// Track duration in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Whether track is available in Hi-Res quality
        /// </summary>
        [JsonPropertyName("hires")]
        public bool HiRes { get; set; }

        /// <summary>
        /// Whether track is available for streaming
        /// </summary>
        [JsonPropertyName("streamable")]
        public bool Streamable { get; set; }

        /// <summary>
        /// Maximum bit depth available
        /// </summary>
        [JsonPropertyName("maximum_bit_depth")]
        public int MaximumBitDepth { get; set; }

        /// <summary>
        /// Maximum sampling rate in kHz (e.g., 44.1, 96, 192)
        /// </summary>
        [JsonPropertyName("maximum_sampling_rate")]
        public decimal MaximumSamplingRate { get; set; }

        /// <summary>
        /// Whether track has explicit content warning
        /// </summary>
        [JsonPropertyName("parental_warning")]
        public bool ParentalWarning { get; set; }

        /// <summary>
        /// Unix timestamp of release date
        /// </summary>
        [JsonPropertyName("released_at")]
        public long ReleasedAt { get; set; }

        /// <summary>
        /// International Standard Recording Code
        /// </summary>
        [JsonPropertyName("isrc")]
        public string Isrc { get; set; }

        /// <summary>
        /// Copyright information
        /// </summary>
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; } = string.Empty;

        /// <summary>
        /// Album this track belongs to
        /// </summary>
        [JsonPropertyName("album")]
        public QobuzAlbum Album { get; set; } = new();

        /// <summary>
        /// Primary performer information
        /// </summary>
        [JsonPropertyName("performer")]
        public TrackPerformer Performer { get; set; } = new();

        /// <summary>
        /// Composer information (optional)
        /// </summary>
        [JsonPropertyName("composer")]
        public TrackComposer Composer { get; set; }
    }
}
