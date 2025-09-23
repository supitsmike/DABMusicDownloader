using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Search
{
    public class Pagination
    {
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("returned")]
        public int Returned { get; set; }
    }
}
