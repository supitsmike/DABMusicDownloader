using System.Text.Json.Serialization;
using QobuzMusicDownloader.Models.Album;
using QobuzMusicDownloader.Models.Artist;

namespace QobuzMusicDownloader.Models.Responses
{
    public class ArtistResponse : ApiResponse<ArtistData>;

    public class ArtistData
    {
        [JsonPropertyName("artist")]
        public QobuzArtist Artist { get; set; } = new();
    }

    public class ReleasesResponse : ApiResponse<ReleasesData>;

    public class ReleasesData
    {
        [JsonPropertyName("albums")]
        public PaginatedResults<QobuzAlbum> Albums { get; set; } = new();
    }
}
