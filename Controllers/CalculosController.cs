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

        /// <summary>
        /// Calcula a área de uma forma geométrica 2D.
        /// </summary>
        /// <param name="formaDto">Objeto representando a forma geométrica.</param>
        /// <returns>Área da forma ou mensagem de erro.</returns>
        /// <response code="200">Retorna a área calculada.</response>
        /// <response code="400">Forma não suporta cálculo de área ou erro de processamento.</response>
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

        /// <summary>
        /// Calcula o perímetro de uma forma geométrica 2D.
        /// </summary>
        /// <param name="formaDto">Objeto representando a forma geométrica.</param>
        /// <returns>Perímetro da forma ou mensagem de erro.</returns>
        /// <response code="200">Retorna o perímetro calculado.</response>
        /// <response code="400">Forma não suporta cálculo de perímetro ou erro de processamento.</response>
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

        /// <summary>
        /// Calcula o volume de uma forma geométrica 3D.
        /// </summary>
        /// <param name="formaDto">Objeto representando a forma geométrica.</param>
        /// <returns>Volume da forma ou mensagem de erro.</returns>
        /// <response code="200">Retorna o volume calculado.</response>
        /// <response code="400">Forma não suporta cálculo de volume ou erro de processamento.</response>
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

        /// <summary>
        /// Calcula a área superficial de uma forma geométrica 3D.
        /// </summary>
        /// <param name="formaDto">Objeto representando a forma geométrica.</param>
        /// <returns>Área superficial da forma ou mensagem de erro.</returns>
        /// <response code="200">Retorna a área superficial calculada.</response>
        /// <response code="400">Forma não suporta cálculo de área superficial ou erro de processamento.</response>
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
