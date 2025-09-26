namespace QobuzMusicDownloader.QobuzDL.Core
{
    /// <summary>
    /// Audio quality levels for download requests
    /// </summary>
    public enum AudioQuality
    {
        /// <summary>
        /// MP3 320kbps - High quality lossy compression
        /// </summary>
        High = 5,

        /// <summary>
        /// FLAC 16-bit/44.1kHz - CD Quality lossless
        /// </summary>
        CdQuality = 6,

        /// <summary>
        /// FLAC 16-bit/44.1kHz - Lossless
        /// </summary>
        Lossless = 7,

        /// <summary>
        /// FLAC up to 24-bit/192kHz - Hi-Res lossless
        /// </summary>
        HiRes = 27
    }
}
