using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Search
{
    public class Album
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("artistId")]
        public int ArtistId { get; set; }

        [JsonPropertyName("cover")]
        public string Cover { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("trackCount")]
        public int TrackCount { get; set; }

        [JsonPropertyName("audioQuality")]
        public AudioQuality AudioQuality { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("genreId")]
        public int GenreId { get; set; }

        [JsonPropertyName("images")]
        public Images Images { get; set; }
    }
}
