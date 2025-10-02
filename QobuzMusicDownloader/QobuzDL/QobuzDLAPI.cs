using QobuzMusicDownloader.Properties;
using QobuzMusicDownloader.QobuzDL.Responses;
using RestSharp;
using System.Net;

namespace QobuzMusicDownloader.QobuzDL
{
    public class QobuzDLAPI
    {
        public static string BaseUrl = Settings.Default.BaseURL;

        private static void CheckForErrors<T>(ApiResponse<T>? response)
        {
            var errorMessage = @"Something went wrong while executing the API request.";
            if (response == null)
            {
                MessageBox.Show(errorMessage, @"API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (response.Success != false || response.Error == null) return;

            if (response.Error is ValidationError[] validationErrors)
            {
                var validationError = validationErrors.FirstOrDefault();
                errorMessage = validationError?.Message;
            }
            else
            {
                errorMessage = Convert.ToString(response.Error);
            }

            MessageBox.Show(errorMessage, @"API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static async Task<SearchResponse?> GetMusicAsync(string query, int offset = 0)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("get-music")
                .AddQueryParameter("q", query)
                .AddQueryParameter("offset", offset)
                .AddHeader("Accept", "application/json")
                .AddHeader("Token-Country", "US");

            try
            {
                var response = await client.ExecuteGetAsync<SearchResponse>(request);
                var result = response.StatusCode == HttpStatusCode.NotFound ? null : response.Data;

                CheckForErrors(result);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in GetMusicAsync: {ex.Message}", ex);
            }
        }

        public static async Task<AlbumResponse?> GetAlbumAsync(string albumId)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("get-album")
                .AddQueryParameter("album_id", albumId)
                .AddHeader("Accept", "application/json")
                .AddHeader("Token-Country", "US");

            try
            {
                var response = await client.ExecuteGetAsync<AlbumResponse>(request);
                var result = response.StatusCode == HttpStatusCode.NotFound ? null : response.Data;

                CheckForErrors(result);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in GetAlbumAsync: {ex.Message}", ex);
            }
        }

        public static async Task<DownloadResponse?> DownloadMusicAsync(int trackId, int quality)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("download-music")
                .AddQueryParameter("track_id", trackId)
                .AddQueryParameter("quality", quality)
                .AddHeader("Accept", "application/json")
                .AddHeader("Token-Country", "US");

            try
            {
                var response = await client.ExecuteGetAsync<DownloadResponse>(request);
                var result = response.StatusCode == HttpStatusCode.NotFound ? null : response.Data;

                CheckForErrors(result);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred in DownloadMusicAsync: {ex.Message}", ex);
            }
        }
    }
}
