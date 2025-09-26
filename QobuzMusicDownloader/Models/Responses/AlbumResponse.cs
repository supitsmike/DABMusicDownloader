using System.Text.Json.Serialization;
using QobuzMusicDownloader.Models.Album;
using QobuzMusicDownloader.Models.Track;

namespace QobuzMusicDownloader.Models.Responses
{
    public class AlbumResponse : ApiResponse<FetchedQobuzAlbum>;

    public class FetchedQobuzAlbum : QobuzAlbum
    {
        [JsonPropertyName("tracks")]
        public PaginatedResults<QobuzTrack> Tracks { get; set; } = new();
    }
}
