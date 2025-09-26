using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.QobuzDL.Track
{
    public class TrackComposer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
