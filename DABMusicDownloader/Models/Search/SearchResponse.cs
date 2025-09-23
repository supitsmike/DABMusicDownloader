using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Search
{
    internal class SearchResponse : ResponseError
    {
        [JsonPropertyName("albums")]
        public List<Album> Albums { get; set; }

        [JsonPropertyName("tracks")]
        public List<Track> Tracks { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
