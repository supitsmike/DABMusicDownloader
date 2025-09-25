using System.Runtime.Serialization;

namespace DABMusicDownloader.Models.QobuzDL
{
    /// <summary>
    /// Search filter categories
    /// </summary>
    public enum SearchFilter
    {
        /// <summary>
        /// Focus on album results
        /// </summary>
        [EnumMember(Value = "albums")]
        Albums,

        /// <summary>
        /// Focus on track results
        /// </summary>
        [EnumMember(Value = "tracks")]
        Tracks,

        /// <summary>
        /// Focus on artist results
        /// </summary>
        [EnumMember(Value = "artists")]
        Artists
    }
}
