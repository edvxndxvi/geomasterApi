using geomasterApi.Interfaces;
using geomasterApi.Models;
using System.Text.Json;

namespace geomasterApi.Factory
{
    public class FactoryContivel
    {

        private readonly Dictionary<string, Func<JsonElement, IFContivel>> _criadoresForma;

        public FactoryContivel()
        {
            _criadoresForma = new Dictionary<string, Func<JsonElement, IFContivel>>(StringComparer.OrdinalIgnoreCase)
            {
                ["circulo"] = CriarCirculoContivel,
                ["retangulo"] = CriarRetanguloContivel
            };
        }

        public IFContivel CriarFormaContivel(string tipo, JsonElement propriedades)
        {
            if (!_criadoresForma.TryGetValue(tipo, out var criador))
            {
                throw new ArgumentException($"Tipo de forma não suportado para contenção: {tipo}");
            }

            return criador(propriedades);
        }

        private IFContivel CriarCirculoContivel(JsonElement propriedades)
        {
            var raio = ValidadorPropriedades.ValidarRaio(propriedades);
            return new CirculoContivel(raio);
        }

        private IFContivel CriarRetanguloContivel(JsonElement propriedades)
        {
            var (largura, altura) = ValidadorPropriedades.ValidarLarguraAltura(propriedades);
            return new RetanguloContivel(largura, altura);
        }

    }
}
