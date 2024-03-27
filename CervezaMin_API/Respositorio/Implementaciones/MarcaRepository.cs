using CervezaMin_API.Datos;
using CervezaMin_API.Models;
using CervezaMin_API.Respositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CervezaMin_API.Respositorio.Implementaciones
{
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        private readonly CervezaContext _context;
        public MarcaRepository(CervezaContext context): base(context)
        {
            _context = context;
        }
        public async Task<Marca> Editar(Marca marca)
        {
            marca.FechaActualizacion = DateTime.Now;
            marca.FechaCreacion = await _context.Marcas.Where(m => m.IdMarca == marca.IdMarca)
                .Select(m=> m.FechaCreacion).FirstOrDefaultAsync();


            _context.Marcas.Update(marca);
            await _context.SaveChangesAsync();
            return marca;
        }
    }
}
