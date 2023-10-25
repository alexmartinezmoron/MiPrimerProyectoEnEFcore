using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Entidades.Configuracion
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            // creamos la llave compuesta
            builder.HasKey(pa => new { pa.ActorId, pa.PeliculaId });

        }
    }
}
