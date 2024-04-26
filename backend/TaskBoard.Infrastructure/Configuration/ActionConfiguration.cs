using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = TaskBoard.Domain.Entities.Action;

namespace TaskBoard.Infrastructure.Configuration
{
    internal class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("actions");
                //t =>
                    //t.Metadata.AddCheckConstraint("CHK_action_action_type", "action_type IN ('Create', 'Update', 'Delete', 'AddCardToList')"));

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("action_id");

            builder
                .Property(c => c.ActionType)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("action_type")
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(s => s.CardId)
                .HasColumnName("card_id");

            builder
                .HasOne(s => s.Card)
                .WithMany()
                .HasForeignKey(s => s.CardId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(s => s.ListCardsId)
                .HasColumnName("list_cards_id");

            builder
                .HasOne(s => s.ListCards)
                .WithMany()
                .HasForeignKey(s => s.ListCardsId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(s => s.ActionTime)
                .HasColumnName("action_time")
                .IsRequired();
        }
    }
}
