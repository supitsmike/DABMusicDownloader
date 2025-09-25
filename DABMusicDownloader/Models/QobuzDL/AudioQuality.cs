using System.Runtime.Serialization;

namespace DABMusicDownloader.Models.QobuzDL
{
    /// <summary>
    /// Audio quality levels for download requests
    /// </summary>
    public enum AudioQuality
    {
        /// <summary>
        /// MP3 320kbps - High quality lossy compression
        /// </summary>
        [EnumMember(Value = "5")]
        High = 5,

        /// <summary>
        /// FLAC 16-bit/44.1kHz - CD Quality lossless
        /// </summary>
        [EnumMember(Value = "6")]
        CdQuality = 6,

        /// <summary>
        /// FLAC 16-bit/44.1kHz - Lossless
        /// </summary>
        [EnumMember(Value = "7")]
        Lossless = 7,

        /// <summary>
        /// FLAC up to 24-bit/192kHz - Hi-Res lossless
        /// </summary>
        [EnumMember(Value = "27")]
        HiRes = 27
    }
}
