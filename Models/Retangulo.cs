using geomasterApi.Interfaces;

namespace geomasterApi.Models
{
    public class Retangulo : FormaRetangular, ICalculos2D
    {
        public double comprimento { get; set; }
        public double largura { get; set; }

        public Retangulo(double comprimento, double largura) : base(comprimento, largura)
        {
            this.comprimento = comprimento;
            this.largura = largura;
        }

        public double CalcularArea()
        {
            return comprimento * largura;
        }

        public double CalcularPerimetro()
        {
            return 2 * (comprimento + largura);

        }
    }
}
