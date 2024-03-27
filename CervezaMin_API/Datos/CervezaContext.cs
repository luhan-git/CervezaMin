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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasData(
                new Marca()
                {
                    IdMarca = 1,
                    Nombre="Cusqueña",
                    Empresa="AB InBev"

                },
                 new Marca()
                 {
                     IdMarca = 2,
                     Nombre = "Cristal",
                     Empresa = "Backus"

                 },
                  new Marca()
                  {
                      IdMarca = 3,
                      Nombre = "Pilsen callao",
                      Empresa = "Backus"

                  }
                ); 
        }

    }
}
