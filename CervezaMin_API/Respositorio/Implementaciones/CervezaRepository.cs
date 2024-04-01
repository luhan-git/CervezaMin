using CervezaMin_API.Datos;
using CervezaMin_API.Models;
using CervezaMin_API.Respositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CervezaMin_API.Respositorio.Implementaciones
{
    public class CervezaRepository : GenericRepository<Cerveza>, ICervezaRepository
    {
        private readonly CervezaContext _context;
        public CervezaRepository(CervezaContext context):base(context)
        {
            _context = context;
        }
        public async Task<Cerveza> Editar(Cerveza cerveza)
        {
            cerveza.FechaActualizacion = DateTime.Now;
            cerveza.FechaCreacion = await _context.Cervezas
                .Where(c => c.IdCerveza == cerveza.IdCerveza)
                .Select(c => c.FechaCreacion).FirstOrDefaultAsync();
            cerveza.EsActivo = true;
            _context.Update(cerveza);
            await _context.SaveChangesAsync();
            return cerveza;
        }
    }
}
