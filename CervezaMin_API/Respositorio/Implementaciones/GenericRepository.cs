using CervezaMin_API.Datos;
using CervezaMin_API.Respositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CervezaMin_API.Respositorio.Implementaciones
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly CervezaContext _context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(CervezaContext context)
        {
            _context = context;
           this.dbSet=_context.Set<TEntity>();
        }
        public async Task<List<TEntity>> Consultar(Expression<Func<TEntity, bool>>? filters = null)
        {
            IQueryable<TEntity> query = filters == null ? dbSet : dbSet.Where(filters);
            return await query.ToListAsync();

        }

        public async Task Crear(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Eliminar(TEntity entity)
        {
            dbSet.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filters, bool tracked = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (!tracked) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filters);
        }
    }
}
