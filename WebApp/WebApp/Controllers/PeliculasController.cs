using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DTOs;
using WebApp.Entidades;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if (pelicula.Generos is not null)
            {
                foreach (var genero in pelicula.Generos)
                {
                    context.Entry(genero).State = EntityState.Unchanged;
                }
            }

            if (pelicula.PeliculasActores is not null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
        }

        // Vamos a utilizar join en las querys

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Comentarios)     // pedimos que no traiga la informacion de la tabla comentarios, pero tenemos una relacion circular entre pelicula y comentario,
                                                 // por lo que en la clase program lo vamos a controlar
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }
            return pelicula;
        }

        [HttpGet("{id:int}/total")]
        public async Task<ActionResult<Pelicula>> GetTotal(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Comentarios)
                .Include(p => p.Generos)
                .Include(p => p.PeliculasActores)  // pelicula no tiene relacion con actor pero pelicula actor si por lo que utilizamos then include para poder llegar a actor
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }
            return pelicula;
        }

        [HttpGet("{id:int}/TotalOrdonado")]
        public async Task<ActionResult<Pelicula>> GetTotalOrdonado(int id)
        {
            var pelicula = await context.Peliculas
                .Include(p => p.Comentarios)
                .Include(p => p.Generos)
                .Include(p => p.PeliculasActores.OrderBy(pa => pa.Orden))  //podemos utilizar orderby en la join
                    .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }
            return pelicula;
        }

        // Como no queremos tada la info vamos a utilar select y la proyecion de datos

        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            var pelicula = await context.Peliculas
                .Select(pel => new
                {
                    pel.Id,
                    pel.Titulo,
                    Generos = pel.Generos.Select(g => g.Nombre).ToList(),
                    Actores = pel.PeliculasActores.OrderBy(pa => pa.Orden).Select(pa =>
                    new {
                        Id = pa.ActorId,
                        pa.Actor.Nombre,
                        pa.Personaje
                    }),
                    CantidadComentarios = pel.Comentarios.Count()
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }
    }
}
