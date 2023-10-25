using AutoMapper;
using WebApp.DTOs;
using WebApp.Entidades;

namespace WebApp.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
        }
    }
}
