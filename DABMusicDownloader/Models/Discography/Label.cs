using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Discography
{
    public class Label
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("albums_count")]
        public int AlbumsCount { get; set; }

        [JsonPropertyName("supplier_id")]
        public int SupplierId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
