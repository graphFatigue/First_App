using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Configuration
{
    internal class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("boards");

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
        }
    }
}
