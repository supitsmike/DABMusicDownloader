using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Album
{
    public class QobuzGenre
    {
        /// <summary>
        /// Unique identifier for the genre
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Genre display name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Hex color code associated with the genre
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Hierarchical path of genre categories
        /// </summary>
        [JsonPropertyName("path")]
        public List<int> Path { get; set; } = [];
    }
}
