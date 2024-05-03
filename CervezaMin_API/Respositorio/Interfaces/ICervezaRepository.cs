using CervezaMin_API.Models;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface ICervezaRepository:ICervezaRepositorySP<Cerveza>
    {
        Task<Cerveza> Editar(Cerveza cerveza);
    }
}
