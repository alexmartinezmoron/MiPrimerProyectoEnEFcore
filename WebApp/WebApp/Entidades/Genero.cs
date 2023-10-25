using System.ComponentModel.DataAnnotations;

namespace WebApp.Entidades
{
    public class Genero
    {

        // Por convencio al ser nombrado como Id se crea como PK en caso de utilizar otro nombre tendriamos que colocar la anotacion KEY ejmpl..
        // Otra manera seria utilizando el api fluente, dejo ejemplo en applicationDBContext
        //[Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;

        // Relaciones
        public HashSet<Pelicula> Peliculas { get; set; } = new HashSet<Pelicula>();
    }
}
