using geomasterApi.Interfaces;

namespace geomasterApi.Models
{
    public class CirculoContivel : Circulo, IFContivel
    {
        public CirculoContivel(double raio) : base(raio) { }

        public bool PodeConter(object formaInterna)
        {
            return formaInterna switch
            {
                CirculoContivel circuloInterno => CirculoPodeConterCirculo(circuloInterno),
                RetanguloContivel retanguloInterno => CirculoPodeConterRetangulo(retanguloInterno),
                _ => false
            };
        }

        private bool CirculoPodeConterCirculo(CirculoContivel circuloInterno)
        {
            return raio >= circuloInterno.raio;
        }

        private bool CirculoPodeConterRetangulo(RetanguloContivel retangulo)
        {
            var diagonal = Math.Sqrt(Math.Pow(retangulo.comprimento, 2) + Math.Pow(retangulo.largura, 2));
            var raioNecessario = diagonal / 2.0;
            return raioNecessario <= raio;
        }
    }
}
