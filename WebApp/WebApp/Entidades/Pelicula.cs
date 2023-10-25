namespace WebApp.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; } 
        public DateTime Fechaestreno { get; set; }

        // relaciones
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();

        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();




    }
}
