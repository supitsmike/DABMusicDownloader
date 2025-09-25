using System.Text.Json.Serialization;

namespace DABMusicDownloader.Models.DABMusic
{
    public class AudioQuality
    {
        [JsonPropertyName("maximumBitDepth")]
        public int MaximumBitDepth { get; set; }

        [JsonPropertyName("maximumSamplingRate")]
        public double MaximumSamplingRate { get; set; }

        [JsonPropertyName("isHiRes")]
        public bool IsHiRes { get; set; }
    }
}
