using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace geomasterApi.DTO
{
    public class FormaRequestDTO
    {
        [Required(ErrorMessage = "O campo tipoForma é obrigatório.")]
        [JsonPropertyName("tipoForma")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo propriedades é obrigatório.")]
        [JsonPropertyName("propriedades")]
        public JsonElement Propriedades { get; set; }
    }

}
