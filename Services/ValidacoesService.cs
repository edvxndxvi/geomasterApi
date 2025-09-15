using geomasterApi.DTO;
using geomasterApi.Interfaces;
using geomasterApi.Models;

namespace geomasterApi.Services
{
  public class ValidacoesService : IValidacoesService
  {
    public bool ValidarFormaContida(ICalculos2D formaExterna, ICalculos2D formaInterna)
    {
      if (formaExterna is Circulo circuloExterno && formaInterna is Circulo circuloInterno)
      {
        return CirculoPodeConterCirculo(circuloExterno, circuloInterno);
      }
      else if (formaExterna is Circulo circuloExterno2 && formaInterna is Retangulo retanguloInterno)
      {
        return CirculoPodeConterRetangulo(circuloExterno2, retanguloInterno);
      }
      else if (formaExterna is Retangulo retanguloExterno && formaInterna is Circulo circuloInterno2)
      {
        return RetanguloPodeConterCirculo(retanguloExterno, circuloInterno2);
      }
      else if (formaExterna is Retangulo retanguloExterno2 && formaInterna is Retangulo retanguloInterno2)
      {
        return RetanguloPodeConterRetangulo(retanguloExterno2, retanguloInterno2);
      }
      return false; // Retorna false se a combinação de formas não for suportada
    }

    private bool CirculoPodeConterCirculo(Circulo circuloExterno, Circulo circuloInterno)
    {
      return circuloExterno.raio >= circuloInterno.raio;
    }

    private bool CirculoPodeConterRetangulo(Circulo circuloExterno, Retangulo retanguloInterno)
    {
      var diagonal = Math.Sqrt(Math.Pow(retanguloInterno.largura, 2) + Math.Pow(retanguloInterno.comprimento, 2));
      var raioNecessario = diagonal / 2.0;
      return raioNecessario <= circuloExterno.raio;
    }

    private bool RetanguloPodeConterCirculo(Retangulo retanguloExterno, Circulo circuloInterno)
    {
      var diametro = circuloInterno.raio * 2;
      return diametro <= retanguloExterno.largura && diametro <= retanguloExterno.comprimento;
    }

    private bool RetanguloPodeConterRetangulo(Retangulo retanguloExterno, Retangulo retanguloInterno)
    {
      // Orientação normal
      bool orientacaoNormal = retanguloInterno.largura <= retanguloExterno.largura &&
                         retanguloInterno.comprimento <= retanguloExterno.comprimento;
      // Orientação rotacionada
      bool orientacaoRotacionada = retanguloInterno.largura <= retanguloExterno.comprimento &&
                         retanguloInterno.comprimento <= retanguloExterno.largura;
      return orientacaoNormal || orientacaoRotacionada;
    }
  }
}