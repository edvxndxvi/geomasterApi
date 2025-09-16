using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace geomasterApi.DTO
{
    public class ContivelRequestDTO
    {
        [Required]
        [JsonPropertyName("formaExterna")]
        public FormaRequestDTO FormaExterna { get; set; } = new();

        [Required]
        [JsonPropertyName("formaInterna")]
        public FormaRequestDTO FormaInterna { get; set; } = new();
    }
}
