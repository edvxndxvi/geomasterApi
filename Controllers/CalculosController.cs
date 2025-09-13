using geomasterApi.DTO;
using geomasterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace geomasterApi.Controllers
{
    [ApiController]
    [Route("api/v1/calculos")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public CalculosController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        [HttpPost("area")]
        public IActionResult CalcularArea([FromBody] FormaDTO formaDto)
        {
            try
            {
                if (formaDto is ICalculos2D forma2D)
                {
                    return Ok(new { Area = _calculadoraService.CalcularArea(forma2D) });
                }
                return BadRequest("Forma não suporta cálculo de área.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("perimetro")]
        public IActionResult CalcularPerimetro([FromBody] FormaDTO formaDto)
        {
            try
            {
                if (formaDto is ICalculos2D forma2D)
                {
                    return Ok(new { Perimetro = _calculadoraService.CalcularPerimetro(forma2D) });
                }
                return BadRequest("Forma não suporta cálculo de perímetro.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("volume")]
        public IActionResult CalcularVolume([FromBody] FormaDTO formaDto)
        {
            try
            {
                if (formaDto is ICalculos3D forma3D)
                {
                    return Ok(new { Volume = _calculadoraService.CalcularVolume(forma3D) });
                }
                return BadRequest("Forma não suporta cálculo de volume.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("areasuperficial")]
        public IActionResult CalcularAreaSuperficial([FromBody] FormaDTO formaDto)
        {
            try
            {
                if (formaDto is ICalculos3D forma3D)
                {
                    return Ok(new { AreaSuperficial = _calculadoraService.CalcularAreaSuperficial(forma3D) });
                }
                return BadRequest("Forma não suporta cálculo de área superficial.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
