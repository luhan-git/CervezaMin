using CervezaMin_API.Models;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface IMarcaRepository : IGenericRepository<Marca>
    {
        Task<Marca> Editar(Marca marca);

    }
}
