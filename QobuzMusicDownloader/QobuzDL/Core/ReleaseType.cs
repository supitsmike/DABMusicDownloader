namespace QobuzMusicDownloader.QobuzDL.Core
{
    /// <summary>
    /// Types of releases available for artist queries
    /// </summary>
    public enum ReleaseType
    {
        /// <summary>
        /// Studio albums and official releases
        /// </summary>
        Album,

        /// <summary>
        /// Live recordings and concert albums
        /// </summary>
        Live,

        /// <summary>
        /// Greatest hits, compilations, and collections
        /// </summary>
        Compilation,

        /// <summary>
        /// EPs, singles, and shorter releases
        /// </summary>
        EpSingle,

        /// <summary>
        /// Digital-only releases
        /// </summary>
        Download
    }
}
