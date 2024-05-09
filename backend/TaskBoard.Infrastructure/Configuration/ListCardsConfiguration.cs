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
                .Property(s => s.BoardId)
                .HasColumnName("board_id");

            builder
                .HasOne(s => s.Board)
                .WithMany(x => x.ListsCards)
                .HasForeignKey(s => s.BoardId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(s => s.Cards)
            //    .WithOne(x => x.ListCards)
            //    .HasForeignKey(s => s.ListCardsId)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
