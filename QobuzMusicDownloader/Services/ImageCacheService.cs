using System.Collections.Concurrent;

namespace QobuzMusicDownloader.Services
{
    public interface IImageCacheService : IDisposable
    {
        Task<Image?> GetImageAsync(string url, string cacheKey);
        void ClearCache();
    }

    public class ImageCacheService : IImageCacheService
    {
        private readonly ConcurrentDictionary<string, Lazy<Task<Image?>>> _cache = new();

        public async Task<Image?> GetImageAsync(string url, string cacheKey)
        {
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(cacheKey))
                return null;

            var lazyTask = _cache.GetOrAdd(cacheKey, _ => new Lazy<Task<Image?>>(
                () => DownloadImageAsync(url),
                LazyThreadSafetyMode.ExecutionAndPublication));

            return await lazyTask.Value;
        }

        private async Task<Image?> DownloadImageAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) return null;

                await using var stream = await response.Content.ReadAsStreamAsync();
                return Image.FromStream(stream);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ClearCache()
        {
            foreach (var lazyTask in _cache.Values)
            {
                if (lazyTask.IsValueCreated && lazyTask.Value.IsCompletedSuccessfully)
                {
                    lazyTask.Value.Result?.Dispose();
                }
            }
            _cache.Clear();
        }

        public void Dispose()
        {
            ClearCache();
            GC.SuppressFinalize(this);
        }
    }
}