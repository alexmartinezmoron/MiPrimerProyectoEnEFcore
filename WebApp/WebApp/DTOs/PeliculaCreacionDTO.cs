using WebApp.Entidades;

namespace WebApp.DTOs
{
    public class PeliculaCreacionDTO
    {

        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime Fechaestreno { get; set; }
        public List<int> Generos { get; set; } = new List<int>();
       public List<PeliculaActorDTO> PeliculasActoresDTO { get; set; } = new List<PeliculaActorDTO>();
    }
}
