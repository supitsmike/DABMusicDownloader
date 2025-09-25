using DABMusicDownloader.Models.DABMusic;
using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic.Search
{
    public class Track
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("artistId")]
        public int ArtistId { get; set; }

        [JsonPropertyName("albumTitle")]
        public string AlbumTitle { get; set; }

        [JsonPropertyName("albumCover")]
        public string AlbumCover { get; set; }

        [JsonPropertyName("albumId")]
        public string AlbumId { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("audioQuality")]
        public AudioQuality AudioQuality { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("labelId")]
        public int LabelId { get; set; }

        [JsonPropertyName("upc")]
        public string Upc { get; set; }

        [JsonPropertyName("mediaCount")]
        public int MediaCount { get; set; }

        [JsonPropertyName("parental_warning")]
        public bool ParentalWarning { get; set; }

        [JsonPropertyName("streamable")]
        public bool Streamable { get; set; }

        [JsonPropertyName("purchasable")]
        public bool Purchasable { get; set; }

        [JsonPropertyName("previewable")]
        public bool Previewable { get; set; }

        [JsonPropertyName("genreId")]
        public int GenreId { get; set; }

        [JsonPropertyName("genreSlug")]
        public string GenreSlug { get; set; }

        [JsonPropertyName("genreColor")]
        public string GenreColor { get; set; }

        [JsonPropertyName("releaseDateStream")]
        public string ReleaseDateStream { get; set; }

        [JsonPropertyName("releaseDateDownload")]
        public string ReleaseDateDownload { get; set; }

        [JsonPropertyName("maximumChannelCount")]
        public int MaximumChannelCount { get; set; }

        [JsonPropertyName("images")]
        public Images Images { get; set; }

        [JsonPropertyName("isrc")]
        public string Isrc { get; set; }
    }
}
