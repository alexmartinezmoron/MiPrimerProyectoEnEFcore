using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.DTOs;
using WebApp.Entidades;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacionDTO)
        {
            /*
            Podemos mapear de forma manual, crear un servicio o como vemos a continuacion utilizar el Imapper: 
                var genero = new Genero();
                genero.Nombre = generoCreacionDTO.Nombre;
            */

            var genero = mapper.Map<Genero>(generoCreacionDTO);

            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        
        }


        // Tambien podemos postear y mapear varios con una collecion en ese caso tendremos que utilizar AddRange
        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generosCreacionDTO)
        {
       
            var generos = mapper.Map<Genero[]>(generosCreacionDTO);

            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
