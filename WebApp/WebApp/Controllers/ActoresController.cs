using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        // Vamos a utilizar FirstOrDefault para que nos traiga el primer registro que encuentre o el de por defecto

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)

        {
            var actor = await context.Actores.FirstOrDefaultAsync(a => a.Id == id);

            if (actor is null)
            {
                return NotFound();
            }
            return actor;
        }

        // order by

        [HttpGet("ordenFechaNacimiento")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetOrdenFechaNacimiento()
        {
            return await context.Actores.OrderBy(a => a.FechaNacimiento).ToListAsync();
        }

        // order by desc

        [HttpGet("ordenFechaNacimientoDescendente")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetOrdenFechaNacimientoDescendente()
        {
            return await context.Actores.OrderByDescending(a => a.FechaNacimiento).ToListAsync();
        }


        [HttpGet("nombre/ordenFechaNacimiento")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetNombreOrdenFechaNacimiento(string nombre)

        {
            // query con where y orderby doble
            return await context.Actores.
                Where(a => a.Nombre.Contains(nombre))
                .OrderBy(a => a.Nombre)
                .ThenBy(a => a.FechaNacimiento)
                .ToListAsync();
        }

        // vamos a hacer un select por columnas y para ello utilizamos una proyecion de un objeto anonimo

        [HttpGet("idYNombre")]
        public async Task<ActionResult<Actor>> GetIdYNombre()
        {
           var actores = await context.Actores.Select(a => new {a.Id, a.Nombre}).ToListAsync();
            return Ok(actores);
        }

        // vamos a hacer un select por columnas y para ello utilizamos una proyecion a un DTO

        [HttpGet("idYNombreDto")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdYNombreDto()
        {
            return await context.Actores
                                .Select(a => new ActorDTO {Id = a.Id, Nombre = a.Nombre }).ToListAsync();
            
        }

        // vamos a hacer un select por columnas pero ahora automapeando el dto 

        [HttpGet("idYNombreDtomapper")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdYNombreDtomapper()
        {
            return await context.Actores
                                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                                .ToListAsync();

        }



    }
}
