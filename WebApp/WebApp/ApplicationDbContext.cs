using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

          //modelBuilder.Entity<Pelicula>().Property(a => a.Titulo).HasMaxLength(150);
            modelBuilder.Entity<Pelicula>().Property(a => a.Fechaestreno).HasColumnType("date");

            modelBuilder.Entity<Comentario>().Property(c => c.Contenido).HasMaxLength(500);


            // aplicamos todas las configuraciones de un Asembly o Proyecto, por lo que buscara desde la carpeta raiz y aplicara todas las configuraciones de IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

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
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
