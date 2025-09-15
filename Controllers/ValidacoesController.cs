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
        /// Verifica se uma forma geométrica pode conter outra forma geométrica.
        /// </summary>
        /// <param name="validacaoDto">Objeto contendo as formas externa e interna para validação.</param>
        /// <returns>Resultado da validação indicando se a forma externa pode conter a forma interna.</returns>
        /// <remarks>
        /// Suporta as seguintes combinações de validação:
        /// - Círculo contendo círculo
        /// - Círculo contendo retângulo
        /// - Retângulo contendo círculo
        /// - Retângulo contendo retângulo
        /// 
        /// Exemplo de requisição:
        /// 
        ///     {
        ///         "formaExterna": {
        ///             "tipo": "circulo",
        ///             "raio": 10
        ///         },
        ///         "formaInterna": {
        ///             "tipo": "retangulo",
        ///             "largura": 5,
        ///             "comprimento": 8
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna o resultado da validação (true se a forma externa pode conter a interna, false caso contrário).</response>
        /// <response code="400">Erro de processamento ou formas inválidas.</response>
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