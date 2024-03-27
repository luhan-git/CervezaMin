using AutoMapper;
using CervezaMin_API.Models;
using CervezaMin_API.Models.Dtos;

namespace CervezaMin_API.Utilidades.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<Marca,MarcaCreateDto>().ReverseMap();
            CreateMap<Marca ,MarcaUpdateDto>().ReverseMap();
        }
    }
}
