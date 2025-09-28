using Microsoft.Extensions.DependencyInjection;
using QobuzMusicDownloader.Forms;
using QobuzMusicDownloader.Services;

namespace QobuzMusicDownloader
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            services.AddSingleton<IImageCacheService, ImageCacheService>();
            services.AddTransient<SearchForm>();
            ServiceProvider = services.BuildServiceProvider();

            Application.Run(ServiceProvider.GetRequiredService<SearchForm>());
        }
    }
}