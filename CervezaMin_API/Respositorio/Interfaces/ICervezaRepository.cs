using CervezaMin_API.Models;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface ICervezaRepository:IGenericRepository<Cerveza>
    {
        Task<Cerveza> Editar(Cerveza cerveza);
    }
}
