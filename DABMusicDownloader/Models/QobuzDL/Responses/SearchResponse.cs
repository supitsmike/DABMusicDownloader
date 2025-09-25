using DABMusicDownloader.Models.QobuzDL.Album;
using DABMusicDownloader.Models.QobuzDL.Artist;
using DABMusicDownloader.Models.QobuzDL.Track;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Responses
{
    public class SearchResponse : ApiResponse<QobuzSearchResults>;

    public class QobuzSearchResults
    {
        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;

        [JsonPropertyName("switchTo")]
        public string? SwitchTo { get; set; } // "albums" | "tracks" | "artists"

        [JsonPropertyName("albums")]
        public PaginatedResults<QobuzAlbum> Albums { get; set; } = new();

        [JsonPropertyName("tracks")]
        public PaginatedResults<QobuzTrack> Tracks { get; set; } = new();

        [JsonPropertyName("artists")]
        public PaginatedResults<QobuzArtist> Artists { get; set; } = new();
    }

    public class PaginatedResults<T>
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("items")]
        public List<T> Items { get; set; } = [];
    }
}
