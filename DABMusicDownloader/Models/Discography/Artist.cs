using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Discography
{
    public class Artist
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("albumsCount")]
        public int AlbumsCount { get; set; }

        [JsonPropertyName("albumsAsPrimaryArtistCount")]
        public int AlbumsAsPrimaryArtistCount { get; set; }

        [JsonPropertyName("albumsAsPrimaryComposerCount")]
        public int AlbumsAsPrimaryComposerCount { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("biography")]
        public Biography Biography { get; set; }

        [JsonPropertyName("similarArtistIds")]
        public List<int> SimilarArtistIds { get; set; }

        [JsonPropertyName("information")]
        public object Information { get; set; }
    }
}
