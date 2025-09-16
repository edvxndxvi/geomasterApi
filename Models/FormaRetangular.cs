namespace geomasterApi.Models
{
    public abstract class FormaRetangular
    {
        public double Largura { get; protected set; }

        public double Comprimento { get; protected set; }

        protected FormaRetangular(double largura, double comprimento)
        {
            ValidarDimensoes(largura, comprimento);
            Largura = largura;
            Comprimento = comprimento;
        }

        private static void ValidarDimensoes(double largura, double comprimento)
        {
            if (largura <= 0 || comprimento <= 0)
                throw new ArgumentException("Largura e comprimento devem ser maiores que zero");
        }
    }
}
