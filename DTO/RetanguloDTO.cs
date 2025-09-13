using System.ComponentModel.DataAnnotations;

namespace geomasterApi.DTO
{
    public class RetanguloDTO : FormaDTO
    {
        [Range(0.0001, double.MaxValue, ErrorMessage = "O comprimento deve ser positivo.")]
        public double Comprimento { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "A largura deve ser positiva.")]
        public double Largura { get; set; }
    }
}
