using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trollo.API.Data.Entities;

namespace Trollo.API.Data.Configurations
{
    public class ListCardConfiguration : IEntityTypeConfiguration<ListCard>
    {
        public void Configure(EntityTypeBuilder<ListCard> builder)
        {
            builder.Property(lc => lc.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(lc => lc.Board).WithMany(b => b.ListCards).HasForeignKey(lc => lc.BoardId);
        }
    }
}