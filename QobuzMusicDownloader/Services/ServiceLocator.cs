using Microsoft.Extensions.DependencyInjection;

namespace QobuzMusicDownloader.Services
{
    public static class ServiceLocator
    {
        public static T GetService<T>() where T : notnull
        {
            return Program.ServiceProvider == null
                ? throw new InvalidOperationException("ServiceProvider is not initialized")
                : Program.ServiceProvider.GetRequiredService<T>();
        }

        public static T? GetOptionalService<T>() where T : class
        {
            return Program.ServiceProvider?.GetService<T>();
        }
    }
}
