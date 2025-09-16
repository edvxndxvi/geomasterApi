using geomasterApi.Interfaces;

namespace geomasterApi.Models
{
    public class Esfera : FormaCircular, ICalculos3D
    {
        public double raio {  get; set; }

        public Esfera(double raio) : base(raio)
        { 
        }

        public double CalcularVolume()
        {
            return ((Math.Pow(raio,3) * Math.PI) * 4) / 3;
        }

        public double CalcularAreaSuperficial()
        {
            return 4 * Math.PI * Math.Pow(raio, 2);
        }
    }
}
