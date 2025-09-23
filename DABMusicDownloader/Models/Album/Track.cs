using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Album
{
    public class Track
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("artistId")]
        public int ArtistId { get; set; }

        [JsonPropertyName("albumTitle")]
        public string AlbumTitle { get; set; }

        [JsonPropertyName("albumCover")]
        public string AlbumCover { get; set; }

        [JsonPropertyName("albumId")]
        public string AlbumId { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("audioQuality")]
        public AudioQuality AudioQuality { get; set; }
    }
}
