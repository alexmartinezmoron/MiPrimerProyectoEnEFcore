using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}
