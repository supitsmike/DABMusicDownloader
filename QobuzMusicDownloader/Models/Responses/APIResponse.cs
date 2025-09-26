using System.Text.Json.Serialization;

namespace QobuzMusicDownloader.Models.Responses
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; } // Can be string or ValidationError[]
    }

    public class ValidationError
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("path")]
        public string[] Path { get; set; } = [];

        [JsonPropertyName("minimum")]
        public int? Minimum { get; set; }

        [JsonPropertyName("maximum")]
        public int? Maximum { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("received")]
        public string Received { get; set; }

        [JsonPropertyName("options")]
        public string[] Options { get; set; }
    }
}
