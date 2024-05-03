using CervezaMin_API.Models;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface IMarcaRepository : ICervezaRepositorySP<Marca>
    {
        Task<Marca> Editar(Marca marca);

    }
}
