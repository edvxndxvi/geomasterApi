using System.Text.Json;

namespace geomasterApi.Interfaces
{
    public interface IFactoryForma
    {
        object CriarForma(string tipo, JsonElement propriedades);
        bool SuportaTipo(string tipo);
    }
}
