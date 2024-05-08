using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Configuration
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("cards"); 
                //t => 
                    //t.Metadata.AddCheckConstraint("CHK_card_priority", "priority IN ('High', 'Medium', 'Low')"));

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("card_id");

            builder
                .Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasColumnName("name")
                .IsRequired();

            builder
                .Property(s => s.Priority)
                .HasColumnName("priority")
                .HasMaxLength(6)
                .HasColumnType("varchar(6)")
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(300)
                .HasColumnType("varchar(300)")
                .HasColumnName("description")
                .IsRequired();

            builder
                .Property(s => s.ListCardsId)
                .HasColumnName("list_cards_id");

            builder
                .HasOne(s => s.ListCards)
                .WithMany(x => x.Cards)
                .HasForeignKey(s => s.ListCardsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(s => s.DueDate)
                .HasColumnName("due_date")
                .IsRequired();
        }
    }
}
