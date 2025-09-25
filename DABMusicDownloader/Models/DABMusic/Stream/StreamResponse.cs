using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Stream
{
    public class StreamResponse : ResponseError
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
