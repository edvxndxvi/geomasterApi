using System.Text.Json;

namespace geomasterApi.Interfaces
{
    public interface IFContivelFactory
    {
        IFContivel CriarFormaContivel(string tipo, JsonElement propriedades);
    }
}
