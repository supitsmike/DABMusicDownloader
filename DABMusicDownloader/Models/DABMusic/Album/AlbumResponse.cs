using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Album
{
    public class AlbumResponse : ResponseError
    {
        [JsonPropertyName("album")]
        public Album Album { get; set; }
    }
}
