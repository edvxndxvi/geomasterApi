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

        public static (double largura, double altura) ValidarLarguraAltura(JsonElement propriedades)
        {
            if (!propriedades.TryGetProperty("comprimento", out var comprimentoElement) ||
                !comprimentoElement.TryGetDouble(out var comprimento) ||
                !propriedades.TryGetProperty("altura", out var alturaElement) ||
                !alturaElement.TryGetDouble(out var altura))
            {
                throw new ArgumentException("Propriedades 'comprimento' e 'altura' são obrigatórias e devem ser números válidos");
            }

            if (comprimento <= 0 || altura <= 0)
            {
                throw new ArgumentException("Largura e altura devem ser maiores que zero");
            }

            return (comprimento, altura);
        }
    }
}
