using GameZilla.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZilla.DataAccess.Data.Configurations
{
    public class GameDeviceConfiguration : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(e =>
                new { e.GameId, e.DeviceId });
        }
    }
}
