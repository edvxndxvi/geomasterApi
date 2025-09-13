using geomasterApi.Interfaces;

namespace geomasterApi.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double CalcularArea(ICalculos2D forma) => forma.CalcularArea();
        public double CalcularPerimetro(ICalculos2D forma) => forma.CalcularPerimetro();
        public double CalcularVolume(ICalculos3D forma) => forma.CalcularVolume();
        public double CalcularAreaSuperficial(ICalculos3D forma) => forma.CalcularAreaSuperficial();
    }
}
