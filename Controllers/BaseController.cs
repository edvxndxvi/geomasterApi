using geomasterApi.DTO;
using geomasterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace geomasterApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly ICalculadoraService _calculadoraService;
        protected readonly IFactoryForma _formaFactory;

        protected BaseController(
            ICalculadoraService calculadoraService,
            IFactoryForma formaFactory)
        {
            _calculadoraService = calculadoraService; _calculadoraService = calculadoraService;
            _formaFactory = formaFactory;
        }

        protected IActionResult ExecutarCalculo(
            FormaRequestDTO request,
            Func<object, double> operacao,
            string nomeOperacao,
            string tiposSuportados)
        {
            try
            {
                // Validar se o tipo é suportado
                if (!_formaFactory.SuportaTipo(request.Tipo))
                {
                    return BadRequest(new ProblemDetails
                    {
                        Title = "Tipo de forma não suportado",
                        Detail = $"O tipo '{request.Tipo}' não é suportado. Tipos válidos: {tiposSuportados}",
                        Status = StatusCodes.Status400BadRequest
                    });
                }

                // Criar a forma usando a factory
                var forma = _formaFactory.CriarForma(request.Tipo, request.Propriedades);

                // Executar o cálculo
                var resultado = operacao(forma);

                return Ok(ResultadoDTO.CriarResponse(request.Tipo, resultado, nomeOperacao));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Dados de entrada inválidos",
                    Detail = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (InvalidOperationException ex)
            {
                return UnprocessableEntity(new ProblemDetails
                {
                    Title = "Operação não suportada",
                    Detail = ex.Message,
                    Status = StatusCodes.Status422UnprocessableEntity
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Erro interno do servidor",
                    Detail = "Ocorreu um erro inesperado ao processar a solicitação",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
