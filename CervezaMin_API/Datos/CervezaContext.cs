using CervezaMin_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CervezaMin_API.Datos
{
    public class CervezaContext:DbContext
    {
        public CervezaContext(DbContextOptions<CervezaContext> options):base(options)
        {
            
        }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Cerveza> Cervezas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasData(
                new Marca()
                {
                    IdMarca = 1,
                    Nombre = "Cusqueña",
                    Empresa = "AB InBev",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now


                },
                 new Marca()
                 {
                     IdMarca = 2,
                     Nombre = "Cristal",
                     Empresa = "Backus",
                     FechaCreacion = DateTime.Now,
                     FechaActualizacion = DateTime.Now

                 },
                  new Marca()
                  {
                      IdMarca = 3,
                      Nombre = "Pilsen callao",
                      Empresa = "Backus",
                      FechaCreacion = DateTime.Now,
                      FechaActualizacion = DateTime.Now

                  }
                );
            modelBuilder.Entity<Cerveza>().HasData(
                new Cerveza()
                {
                    IdCerveza = 1,
                    IdMarca = 1,
                    Nombre = "Cusqueña Dorada",
                    NombreImagen = "CusqueñaDorada",
                    UrlImagen = "https://srv.com/cervezasMin/cusqueñaDorada.webp",
                    Precio = 12,
                    Stock = 1,
                    EsActivo = true,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now


                },
                new Cerveza()
                {
                    IdCerveza = 2,
                    IdMarca = 1,
                    Nombre = "Cusqueña Negra",
                    NombreImagen = "CusqueñaNegra",
                    UrlImagen = "https://srv.com/cervezasMin/cusqueñaNegra.webp",
                    Precio = 15,
                    Stock = 1,
                    EsActivo = true,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now


                },
                new Cerveza()
                {
                    IdCerveza = 3,
                    IdMarca = 1,
                    Nombre = "Cusqueña Trigo",
                    NombreImagen = "CusqueñaTrigo",
                    UrlImagen = "https://srv.com/cervezasMin/cusqueñaTrigo.webp",
                    Precio = 15,
                    Stock = 1,
                    EsActivo = true,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now


                },
                new Cerveza()
                {
                    IdCerveza = 4,
                    IdMarca = 2,
                    Nombre = "Cristal Rubia",
                    NombreImagen = "CristalRubia",
                    UrlImagen = "https://srv.com/cervezasMin/cristalrubia.webp",
                    Precio = 15,
                    Stock = 1,
                    EsActivo = true,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now


                },
                 new Cerveza()
                 {
                     IdCerveza = 5,
                     IdMarca = 3,
                     Nombre = "Pilsen Callao",
                     NombreImagen = "Pilsen Callao",
                     UrlImagen = "https://srv.com/cervezasMin/pilsenCallao.webp",
                     Precio = 15,
                     Stock = 1,
                     EsActivo = true,
                     FechaCreacion = DateTime.Now,
                     FechaActualizacion = DateTime.Now


                 }

                ) ;

        }

    }
}
