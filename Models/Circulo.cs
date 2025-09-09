using geomasterApi.Interfaces;

namespace geomasterApi.Models
{
    public class Circulo : ICalculos2D
    {
        public double raio { get; set; }

        public Circulo(double raio)
        {
            this.raio = raio;
        }

        public double CalcularArea()
        {
            return Math.PI * (raio * raio);
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * raio;
        }
    }
}
