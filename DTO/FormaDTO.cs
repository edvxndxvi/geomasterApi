using System.ComponentModel.DataAnnotations;

namespace geomasterApi.DTO
{
    public abstract class FormaDTO
    {
        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        public string Tipo { get; set; }
    }

}
