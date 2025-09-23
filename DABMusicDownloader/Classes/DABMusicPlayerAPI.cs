using DABMusicDownloader.Models.Album;
using DABMusicDownloader.Models.Discography;
using DABMusicDownloader.Models.Search;
using DABMusicDownloader.Models.Stream;
using DABMusicDownloader.Properties;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace DABMusicDownloader.Classes
{
    internal class DABMusicPlayerAPI
    {
        private static readonly string BaseUrl = Settings.Default.BaseURL;

        public static async Task<SearchResponse?> SearchAsync(string query, SearchType type, int limit = 0, int offset = 0)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("search")
                .AddQueryParameter("q", query)
                .AddQueryParameter("type", type.ToString().ToLower())
                .AddQueryParameter("limit", limit)
                .AddQueryParameter("offset", offset)
                .AddHeader("Accept", "application/json");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                return string.IsNullOrWhiteSpace(response.Content) == false
                    ? JsonSerializer.Deserialize<SearchResponse>(response.Content)
                    : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in SearchAsync: {ex.Message}", ex);
            }
        }

        public static async Task<AlbumResponse?> AlbumAsync(string albumId)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("album")
                .AddQueryParameter("albumId", albumId)
                .AddHeader("Accept", "application/json");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                return string.IsNullOrWhiteSpace(response.Content) == false
                    ? JsonSerializer.Deserialize<AlbumResponse>(response.Content)
                    : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in AlbumAsync: {ex.Message}", ex);
            }
        }

        public static async Task<DiscographyResponse?> DiscographyAsync(string artistId)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("discography")
                .AddQueryParameter("artistId ", artistId)
                .AddHeader("Accept", "application/json");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                return string.IsNullOrWhiteSpace(response.Content) == false
                    ? JsonSerializer.Deserialize<DiscographyResponse>(response.Content)
                    : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in DiscographyAsync: {ex.Message}", ex);
            }
        }

        public static async Task<AlbumResponse?> DownloadAsync(string albumId, string quality = "27")
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("download")
                .AddQueryParameter("albumId ", albumId)
                .AddQueryParameter("quality ", quality)
                .AddHeader("Accept", "application/json");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                return string.IsNullOrWhiteSpace(response.Content) == false
                    ? JsonSerializer.Deserialize<AlbumResponse>(response.Content)
                    : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in DownloadAsync: {ex.Message}", ex);
            }
        }

        public static async Task<StreamResponse?> StreamAsync(string albumId, string quality = "27")
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("stream")
                .AddQueryParameter("albumId ", albumId)
                .AddQueryParameter("quality ", quality)
                .AddHeader("Accept", "application/json");

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                return string.IsNullOrWhiteSpace(response.Content) == false
                    ? JsonSerializer.Deserialize<StreamResponse>(response.Content)
                    : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in StreamAsync: {ex.Message}", ex);
            }
        }
    }
}
