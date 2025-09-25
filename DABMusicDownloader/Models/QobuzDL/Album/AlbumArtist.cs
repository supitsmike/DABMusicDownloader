using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Album
{
    public class AlbumArtist
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Artist roles (e.g., "MainArtist", "Producer")
        /// </summary>
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = [];
    }
}
