using System.Runtime.Serialization;

namespace QobuzMusicDownloader.Models
{
    /// <summary>
    /// Types of releases available for artist queries
    /// </summary>
    public enum ReleaseType
    {
        /// <summary>
        /// Studio albums and official releases
        /// </summary>
        [EnumMember(Value = "album")]
        Album,

        /// <summary>
        /// Live recordings and concert albums
        /// </summary>
        [EnumMember(Value = "live")]
        Live,

        /// <summary>
        /// Greatest hits, compilations, and collections
        /// </summary>
        [EnumMember(Value = "compilation")]
        Compilation,

        /// <summary>
        /// EPs, singles, and shorter releases
        /// </summary>
        [EnumMember(Value = "epSingle")]
        EpSingle,

        /// <summary>
        /// Digital-only releases
        /// </summary>
        [EnumMember(Value = "download")]
        Download
    }
}
