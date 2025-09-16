using geomasterApi.Controllers;
using geomasterApi.DTO;
using geomasterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/calculos")]
[Produces("application/json")]
public class CalculosController : BaseController
{

    public CalculosController(
    ICalculadoraService calculadoraService,
    IFactoryForma formaFactory) : base(calculadoraService, formaFactory)
    {
    }

    /// <summary>
    /// Calcula a área de uma forma geométrica 2D
    /// </summary>
    /// <param name="request">Dados da forma geométrica</param>
    /// <returns>Resultado do cálculo da área</returns>
    /// <response code="200">Cálculo realizado com sucesso</response>
    /// <response code="400">Dados de entrada inválidos</response>
    /// <response code="422">Operação não suportada para o tipo de forma</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpPost("area")]
    [ProducesResponseType(typeof(ResultadoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public IActionResult CalcularArea([FromBody] FormaRequestDTO request)
    {
        return ExecutarCalculo(
            request,
            forma => _calculadoraService.CalcularArea((ICalculos2D)forma),
            "area",
            "circulo, retangulo"
        );
    }

    /// <summary>
    /// Calcula o perímetro de uma forma geométrica 2D
    /// </summary>
    /// <param name="request">Dados da forma geométrica</param>
    /// <returns>Resultado do cálculo do perímetro</returns>
    /// <response code="200">Cálculo realizado com sucesso</response>
    /// <response code="400">Dados de entrada inválidos</response>
    /// <response code="422">Operação não suportada para o tipo de forma</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpPost("perimetro")]
    [ProducesResponseType(typeof(ResultadoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public IActionResult CalcularPerimetro([FromBody] FormaRequestDTO request)
    {
        return ExecutarCalculo(request, forma => _calculadoraService.CalcularPerimetro((ICalculos2D)forma), "perimetro", "circulo, retangulo");
    }

    /// <summary>
    /// Calcula o volume de uma forma geométrica 3D
    /// </summary>
    /// <param name="request">Dados da forma geométrica</param>
    /// <returns>Resultado do cálculo do volume</returns>
    /// <response code="200">Cálculo realizado com sucesso</response>
    /// <response code="400">Dados de entrada inválidos</response>
    /// <response code="422">Operação não suportada para o tipo de forma</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpPost("volume")]
    [ProducesResponseType(typeof(ResultadoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public IActionResult CalcularVolume([FromBody] FormaRequestDTO request)
    {
        return ExecutarCalculo(request, forma => _calculadoraService.CalcularVolume((ICalculos3D) forma), "volume", "esfera");
    }

    /// <summary>
    /// Calcula a área superficial de uma forma geométrica 3D
    /// </summary>
    /// <param name="request">Dados da forma geométrica</param>
    /// <returns>Resultado do cálculo da área superficial</returns>
    /// <response code="200">Cálculo realizado com sucesso</response>
    /// <response code="400">Dados de entrada inválidos</response>
    /// <response code="422">Operação não suportada para o tipo de forma</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpPost("areasuperficial")]
    [ProducesResponseType(typeof(ResultadoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public IActionResult CalcularAreaSuperficial([FromBody] FormaRequestDTO request)
    {
        return ExecutarCalculo(request, forma => _calculadoraService.CalcularAreaSuperficial((ICalculos3D) forma), "area superficial", "esfera");
    }
}
