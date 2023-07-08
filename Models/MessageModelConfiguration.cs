using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestRelationship.Models;

public class MessageModelConfiguration : IEntityTypeConfiguration<MessageModel>
{
    public void Configure(EntityTypeBuilder<MessageModel> builder)
    {
        builder.ToTable("Messages");

        builder
            .Property(m => m.MessageText)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500);

        builder
            .HasOne(m => m.Sender)
            .WithMany(s => s.SendMessageList)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(m => m.Reciver)
            .WithMany(s => s.ReceiveMessageList)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .Property(m => m.Active)
            .HasColumnType("BIT")
            .HasDefaultValue(true);

        builder
            .Property(m => m.CreateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        builder
            .Property(m => m.UpdateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}