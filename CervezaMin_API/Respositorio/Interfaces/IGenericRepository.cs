using System.Linq.Expressions;

namespace CervezaMin_API.Respositorio.Interfaces
{
    public interface ICervezaRepositorySP<TEntity> where TEntity : class
    {
        Task Crear(TEntity entity);
        Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filters, bool tracked = true);
        Task<List<TEntity>> Consultar(Expression<Func<TEntity, bool>>? filters = null);
        Task Eliminar(TEntity entity);

    }
}
