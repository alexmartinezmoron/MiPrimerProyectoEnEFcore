using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace WebApp.Entidades.Configuracion
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //modelBuilder.Entity<Actor>().Property(a => a.Nombre).HasMaxLength(150);
            builder.Property(a => a.FechaNacimiento).HasColumnType("date");

            // la precision va a ser de 18 digitos con solo 2 decimales
            builder.Property(a => a.Fortuna).HasPrecision(18, 2);
        }
    }
}
