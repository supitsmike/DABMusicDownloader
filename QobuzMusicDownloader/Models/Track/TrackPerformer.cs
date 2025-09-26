using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.Models.Track
{
    public class TrackPerformer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
