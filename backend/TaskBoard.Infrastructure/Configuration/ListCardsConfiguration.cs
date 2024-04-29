using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Configuration
{
    internal class ListCardsConfiguration : IEntityTypeConfiguration<ListCards>
    {
        public void Configure(EntityTypeBuilder<ListCards> builder)
        {
            builder.ToTable("list_cards");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("list_cards_id");

            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .Property(c => c.Name)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)")
                .HasColumnName("name")
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(300)
                .HasColumnType("varchar(300)")
                .HasColumnName("description");
        }
    }
}
