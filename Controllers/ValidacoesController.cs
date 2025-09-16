using geomasterApi.DTO;
using geomasterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace geomasterApi.Controllers
{
    [ApiController]
    [Route("api/v1/validacoes")]
    public class ValidacoesController : ControllerBase
    {
        private readonly IValidacoesService _validacoesService;

        public ValidacoesController(IValidacoesService validacoesService)
        {
            _validacoesService = validacoesService;
        }

        /// <summary>
        /// Determina se uma forma geométrica externa consegue conter outra forma geométrica interna.
        /// </summary>
        /// <param name="validacaoDto">Objeto que contém as informações das formas externa e interna a serem validadas.</param>
        /// <returns>Um valor booleano indicando se a forma externa pode conter a forma interna.</returns>
        /// <response code="200">Validação concluída com sucesso. Retorna true se a forma externa pode conter a interna; false caso contrário.</response>
        /// <response code="400">Solicitação inválida ou erro ao processar as formas fornecidas.</response>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult ValidarFormaContida([FromBody] ValidacaoFormasDTO validacaoDto)
        {
            try
            {
                if (validacaoDto?.FormaExterna == null || validacaoDto?.FormaInterna == null)
                {
                    return BadRequest("As formas externa e interna devem ser fornecidas.");
                }

                // Verifica se as formas implementam ICalculos2D
                if (validacaoDto.FormaExterna is not ICalculos2D formaExterna)
                {
                    return BadRequest("A forma externa deve ser uma forma 2D válida.");
                }

                if (validacaoDto.FormaInterna is not ICalculos2D formaInterna)
                {
                    return BadRequest("A forma interna deve ser uma forma 2D válida.");
                }

                bool podeConter = _validacoesService.ValidarFormaContida(formaExterna, formaInterna);

                return Ok(new 
                { 
                    podeConter
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar validação: {ex.Message}");
            }
        }
    }
}