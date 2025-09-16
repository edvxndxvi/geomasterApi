using geomasterApi.Interfaces;

namespace geomasterApi.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double CalcularArea(ICalculos2D forma)
        {
            return forma switch
            {
                ICalculos2D forma2d => forma2d.CalcularArea(),
                _ => throw new InvalidOperationException("A forma não calcula área 2d ")
            };
        }

        public double CalcularPerimetro(ICalculos2D forma)
        {
            return forma switch
            {
                ICalculos2D forma2d => forma2d.CalcularPerimetro(),
                _ => throw new InvalidOperationException("A forma não calcula perímetro")
            };
        }
        public double CalcularVolume(ICalculos3D forma)
        {
            return forma switch
            {
                ICalculos3D forma3d => forma3d.CalcularVolume(),
                _ => throw new InvalidOperationException("A forma não calcula volume")
            };
        }
        public double CalcularAreaSuperficial(ICalculos3D forma)
        {
            return forma switch
            {
                ICalculos3D forma3d => forma3d.CalcularAreaSuperficial(),
                _ => throw new InvalidOperationException("A forma não calcula area superficial")
            };

        }
    }
}
