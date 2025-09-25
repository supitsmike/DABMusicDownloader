using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Discography
{
    public class DiscographyResponse : ResponseError
    {
        [JsonPropertyName("artist")]
        public Artist Artist { get; set; }

        [JsonPropertyName("albums")]
        public List<Album> Albums { get; set; }
    }
}
