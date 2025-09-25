using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Album
{
    public class Album
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("cover")]
        public string Cover { get; set; }

        [JsonPropertyName("tracks")]
        public List<Track> Tracks { get; set; }

        [JsonPropertyName("trackCount")]
        public int TrackCount { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("audioQuality")]
        public AudioQuality AudioQuality { get; set; }
    }
}
