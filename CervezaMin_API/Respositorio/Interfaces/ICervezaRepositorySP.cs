using CervezaMin_API.Models;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface ICervezaRepositorySP
    {
        Task Crear(Cerveza cerveza);
    }
}
