using GameZilla.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZilla.DataAccess.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(2500);
            builder.Property(x => x.Cover).HasMaxLength(500);
        }
    }
}
