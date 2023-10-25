using Microsoft.AspNetCore.Mvc;
using WebApp.Entidades;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok();
        
        }
    }
}
