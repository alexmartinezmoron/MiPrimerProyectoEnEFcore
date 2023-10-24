using Microsoft.EntityFrameworkCore;
using WebApp.Entidades;

namespace WebApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //api fluiente para establecer un metodo de clave primaria
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // utilizamos el api fluente para establecer la PK pero como por convencion el usar Id no es necesario lo dejamos comentado solo como ejemplo
            // modelBuilder.Entity<Genero>().HasKey(g => g.Id);


            // en este caso vamos a utilizar el api fliente para establecer el maximo de arracteres en lugar de un atributo en la propia clase
            modelBuilder.Entity<Actor>().Property(a => a.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(a => a.FechaNacimiento).HasColumnType("date");

            // la precision va a ser de 18 digitos con solo 2 decimales
            modelBuilder.Entity<Actor>().Property(a => a.Fortuna).HasPrecision(18, 2);

            modelBuilder.Entity<Pelicula>().Property(a => a.Titulo).HasMaxLength(150);
            modelBuilder.Entity<Pelicula>().Property(a => a.Fechaestreno).HasColumnType("date");

            modelBuilder.Entity<Comentario>().Property(c => c.Contenido).HasMaxLength(150);

        }

        // como estamos indicando continuamente que los string van a ser varchar de 150 lo podemos definir dirrectamente por convencion

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
    }
}
