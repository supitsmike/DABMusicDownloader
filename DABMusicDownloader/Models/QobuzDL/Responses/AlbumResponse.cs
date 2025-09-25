using DABMusicDownloader.Models.QobuzDL.Album;
using DABMusicDownloader.Models.QobuzDL.Track;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.QobuzDL.Responses
{
    public class AlbumResponse : ApiResponse<FetchedQobuzAlbum>;

    public class FetchedQobuzAlbum : QobuzAlbum
    {
        [JsonPropertyName("tracks")]
        public PaginatedResults<QobuzTrack> Tracks { get; set; } = new();
    }
}
