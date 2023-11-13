using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DTOs;
using WebApp.Entidades;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
      

            var actor = mapper.Map<Actor>(actorCreacionDTO);

            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        
        }


        [HttpPost("varios")]
        public async Task<ActionResult> Post(ActorCreacionDTO[] actorCreacionDTO)
        {
       
            var actor = mapper.Map<Actor[]>(actorCreacionDTO);

            context.AddRange(actor);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actores.ToListAsync();
        }

        [HttpGet ("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre)

        {
            // Version con uno utilizando equals
            return await context.Actores.Where(a => a.Nombre == nombre).ToListAsync();
        }

        [HttpGet("nombre/V2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string nombre)

        {
            // Version con uno utilizando contains
            return await context.Actores.Where(a => a.Nombre.Contains(nombre)).ToListAsync();
        }


        // vamos a utilizar operradoner en la consulta como and u or
        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime inicio, DateTime fin)

        {
            // Version con and
            return await context.Actores.Where(a => a.FechaNacimiento >= inicio && a.FechaNacimiento <= fin).ToListAsync();
        }


    }
}
