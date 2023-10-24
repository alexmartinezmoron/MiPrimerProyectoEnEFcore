namespace WebApp.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; } 
        public DateTime Fechaestreno { get; set; }
    }
}
