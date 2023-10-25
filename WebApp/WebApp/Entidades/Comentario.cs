namespace WebApp.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }

        // al añadir ? indicamos que puede ser nulable
        public string? Contenido { get; set; }
        public bool Recomendar {  get; set; }


        //Configuramos las relaciones por convencion
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;

    }
}
