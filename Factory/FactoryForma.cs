using geomasterApi.Interfaces;
using geomasterApi.Models;
using System.Text.Json;
namespace geomasterApi.Factory
{
    public class FactoryForma: IFactoryForma
    {

        private readonly Dictionary<string, Func<JsonElement, object>> criadorForma;

        public FactoryForma()
        {
            criadorForma = new Dictionary<string, Func<JsonElement, object>>(StringComparer.OrdinalIgnoreCase)
            {
                ["circulo"] = CriarCirculo,
                ["retangulo"] = CriarRetangulo,
                ["esfera"] = CriarEsfera
            };
        }

        public object CriarForma(string tipo, JsonElement propriedades)
        {
            if (!criadorForma.TryGetValue(tipo, out var criador))
            {
                throw new ArgumentException($"Tipo de forma '{tipo}' não é suportado");
            }
            return criador(propriedades);
        }

        public bool SuportaTipo(string tipo)
        {
            return criadorForma.ContainsKey(tipo);
        }

        private object CriarCirculo(JsonElement props)
        {
            var raio = ValidadorPropriedades.ValidarRaio(props);
            return new Circulo(raio);
        }

        private object CriarRetangulo(JsonElement props)
        {
            var (largura, comprimento) = ValidadorPropriedades.ValidarLarguraComprimento(props);
            return new Retangulo(largura, comprimento);
        }

        private object CriarEsfera(JsonElement props)
        {
            var raio = ValidadorPropriedades.ValidarRaio(props);
            return new Esfera(raio);
        }
    }
}
