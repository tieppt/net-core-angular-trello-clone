using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trollo.API.Data.Entities;

namespace Trollo.API.Data.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(c => c.ListCard).WithMany(lc => lc.Cards).HasForeignKey(c => c.ListCardId);
        }
    }
}