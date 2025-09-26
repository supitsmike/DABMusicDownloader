using System.Text.Json.Serialization;
using QobuzMusicDownloader.QobuzDL.Album;
using QobuzMusicDownloader.QobuzDL.Track;

namespace QobuzMusicDownloader.QobuzDL.Responses
{
    public class AlbumResponse : ApiResponse<FetchedQobuzAlbum>;

    public class FetchedQobuzAlbum : QobuzAlbum
    {
        [JsonPropertyName("tracks")]
        public PaginatedResults<QobuzTrack> Tracks { get; set; } = new();
    }
}
