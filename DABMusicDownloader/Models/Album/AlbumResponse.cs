using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.Album
{
    public class AlbumResponse : ResponseError
    {
        [JsonPropertyName("album")]
        public Album Album { get; set; }
    }
}
