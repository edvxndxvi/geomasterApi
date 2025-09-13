using geomasterApi.DTO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace geomasterApi.Converter
{
    public class FormaDtoConverter : JsonConverter<FormaDTO>
    {
        public override FormaDTO? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var root = jsonDoc.RootElement;

            var tipo = root.GetProperty("Tipo").GetString();

            return tipo switch
            {
                "Circulo" => JsonSerializer.Deserialize<CirculoDTO>(root.GetRawText(), options),
                "Retangulo" => JsonSerializer.Deserialize<RetanguloDTO>(root.GetRawText(), options),
                "Esfera" => JsonSerializer.Deserialize<EsferaDTO>(root.GetRawText(), options),
                _ => throw new InvalidOperationException("Tipo de forma inválido")
            };
        }

        public override void Write(Utf8JsonWriter writer, FormaDTO value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }

}
