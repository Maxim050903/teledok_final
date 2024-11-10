using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using teledok.Teledok.DataBase.Entities;

namespace teledok.Teledok.DataBase.Configurations
{
    public class FounderConfiguration : IEntityTypeConfiguration<FounderEntity>
    {
        public void Configure(EntityTypeBuilder<FounderEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.Full_Name).IsRequired();
        }
    }
}
