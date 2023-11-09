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
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<ComentarioCreacionDTO, Comentario>();


            // vamos a necesitar crear una proyeccion que en peliculaCreacion el genero es una lista de int
            CreateMap<PeliculaCreacionDTO, Pelicula>()
               .ForMember(ent => ent.Generos, dto =>
               dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));

            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }
}
