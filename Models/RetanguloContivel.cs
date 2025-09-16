using geomasterApi.Interfaces;

namespace geomasterApi.Models
{
    public class RetanguloContivel : Retangulo, IFContivel
    {
        public RetanguloContivel(double largura, double altura) : base(largura, altura) { }

        public bool PodeConter(object formaInterna)
        {
            return formaInterna switch
            {
                CirculoContivel circuloInterno => RetanguloPodeConterCirculo(circuloInterno),
                RetanguloContivel retanguloInterno => RetanguloPodeConterRetangulo(retanguloInterno),
                _ => false
            };
        }

        private bool RetanguloPodeConterCirculo(CirculoContivel circulo)
        {
            var diametro = circulo.raio * 2;
            return diametro <= this.largura && diametro <= this.comprimento;
        }

        private bool RetanguloPodeConterRetangulo(RetanguloContivel retanguloInterno)
        {
            bool orientacaoNormal = retanguloInterno.largura <= largura &&
                               retanguloInterno.comprimento <= comprimento;

            bool orientacaoRotacionada = retanguloInterno.largura <= comprimento &&
                               retanguloInterno.comprimento <= largura;
            return orientacaoNormal || orientacaoRotacionada;
        }
    }
}
