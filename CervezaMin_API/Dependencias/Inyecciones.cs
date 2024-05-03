using CervezaMin_API.Datos;
using CervezaMin_API.Respositorio.Implementaciones;
using CervezaMin_API.Respositorio.Interfaces;
using CervezaMin_API.Utilidades.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CervezaMin_API.Dependencias
{
    public static class Inyecciones
    {
        public static void Inyeccion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CervezaContext>(option => option.UseSqlServer(configuration.GetConnectionString("Context")));
            services.AddTransient(typeof(ICervezaRepositorySP<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<ICervezaRepository,CervezaRepository>();
            services.AddScoped<ICervezaRepositorySP, CervezaRepositorySP>();
        }
    }
}
