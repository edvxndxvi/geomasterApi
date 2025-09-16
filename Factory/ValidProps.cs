using System.Text.Json;

namespace geomasterApi.Factory
{
    public static class ValidadorPropriedades
    {

        public static double ValidarRaio(JsonElement propriedades)
        {
            if (!propriedades.TryGetProperty("raio", out var raioElement) ||
                !raioElement.TryGetDouble(out var raio))
            {
                throw new ArgumentException("Propriedade 'raio' é obrigatória e deve ser um número válido");
            }

            if (raio <= 0)
            {
                throw new ArgumentException("O raio deve ser maior que zero");
            }

            return raio;
        }

        public static (double largura, double comprimento) ValidarLarguraComprimento(JsonElement propriedades)
        {
            if (!propriedades.TryGetProperty("largura", out var larguraElement) ||
                !larguraElement.TryGetDouble(out var largura) ||
                !propriedades.TryGetProperty("comprimento", out var comprimentoElement) ||
                !comprimentoElement.TryGetDouble(out var comprimento))
            {
                throw new ArgumentException("Propriedades 'comprimento' e 'largura' são obrigatórias e devem ser números válidos");
            }

            if (comprimento <= 0 || largura <= 0)
            {
                throw new ArgumentException("Largura e comprimento devem ser maiores que zero");
            }

            return (comprimento, largura);
        }
    }
}
