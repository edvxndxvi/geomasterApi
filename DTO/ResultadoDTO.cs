namespace geomasterApi.DTO
{
    public class ResultadoDTO
    {
        public string tipo { get; set; } = string.Empty;
        public double resultado { get; set; }
        public string operacao { get; set; } = string.Empty;
        public DateTime dataCalculo { get; set; } = DateTime.UtcNow;


        public static ResultadoDTO CriarResponse(string tipo, double resultado, string operacao)
        {
            return new ResultadoDTO
            {
                tipo = tipo,
                resultado = Math.Round(resultado, 3),
                operacao = operacao
            };
        }
    }
}
