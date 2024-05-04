using CervezaMin_API.Datos;
using CervezaMin_API.Models;
using CervezaMin_API.Respositorio.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CervezaMin_API.Respositorio.Implementaciones
{
    public class CervezaRepositorySP :GenericRepository<Cerveza>, ICervezaRepositorySP
    {
        private readonly CervezaContext _context;
        public CervezaRepositorySP(CervezaContext context):base(context)
        {
            _context = context;
        }
        public async Task Crearsp(Cerveza cerveza)
        {
            string sql = "EXEC spCrearCerveza @idMarca, @Nombre, @NombreImagen,@UrlImagen,@Precio,@stok";
            await _context.Database.ExecuteSqlRawAsync(sql,
                new SqlParameter("@idMarca", cerveza.IdMarca),
                new SqlParameter("@Nombre", cerveza.Nombre),
                new SqlParameter("@NombreImagen",cerveza.NombreImagen),
                new SqlParameter("@UrlImagen", cerveza.UrlImagen),
                new SqlParameter("@Precio", cerveza.Precio),
                new SqlParameter("@stok", cerveza.Stock)
                );
        }
    }
}
