using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Discography
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
        public List<object> Tracks { get; set; }

        [JsonPropertyName("trackCount")]
        public int TrackCount { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("audioQuality")]
        public AudioQuality AudioQuality { get; set; }

        [JsonPropertyName("label")]
        public Label Label { get; set; }

        [JsonPropertyName("upc")]
        public string Upc { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("streamable")]
        public bool Streamable { get; set; }

        [JsonPropertyName("downloadable")]
        public bool Downloadable { get; set; }

        [JsonPropertyName("mediaCount")]
        public int MediaCount { get; set; }

        [JsonPropertyName("maximumChannelCount")]
        public int MaximumChannelCount { get; set; }

        [JsonPropertyName("parental_warning")]
        public bool ParentalWarning { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
    }
}
