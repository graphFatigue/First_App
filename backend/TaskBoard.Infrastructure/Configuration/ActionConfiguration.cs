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
                .Property(c => c.Message)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .HasColumnName("message")
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(s => s.CardId)
                .HasColumnName("card_id");

            builder
                .HasOne(s => s.Card)
                .WithMany(c => c.Actions)
                .HasForeignKey(s => s.CardId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .Property(s => s.ActionTime)
                .HasColumnName("action_time")
                .IsRequired();
        }
    }
}
