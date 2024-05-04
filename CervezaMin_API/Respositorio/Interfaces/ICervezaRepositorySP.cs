using CervezaMin_API.Models;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface ICervezaRepositorySP:IGenericRepository<Cerveza>
    {
        Task Crearsp(Cerveza cerveza);
    }
}
