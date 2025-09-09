using geomasterApi.Interfaces;

namespace geomasterApi.Models
{
    public class Retangulo : ICalculos2D
    {
        public double comprimento { get; set; }
        public double largura { get; set; }

        public Retangulo(double comprimento, double largura)
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
            return 2 * (comprimento * largura); 
        }
    }
}
