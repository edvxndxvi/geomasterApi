using System.ComponentModel.DataAnnotations;

namespace geomasterApi.DTO
{
    public class CirculoDTO : FormaDTO
    {
        [Range(0.0001, double.MaxValue, ErrorMessage = "O raio deve ser positivo.")]
        public double Raio { get; set; }
    }
}
