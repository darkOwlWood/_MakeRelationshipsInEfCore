using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestRelationship.Models;

public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("Users");

        builder
            .Property(u => u.UserModelId)
            .HasColumnName("UserId");

        builder
            .Property(u => u.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder
            .Property(u => u.LastName)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder
            .Property(u => u.Age)
            .HasColumnType("SMALLINT");

        builder
            .Property(u => u.Email)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder
            .Property(u => u.Birthday)
            .HasColumnType("DATETIME");

        builder
            .Property(u => u.IsDeveloper)
            .HasColumnType("BIT")
            .HasDefaultValue(true);

        builder
            .Property(u => u.Active)
            .HasColumnType("BIT")
            .HasDefaultValue(true);

        builder
            .Property(u => u.CreateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        builder
            .Property(u => u.UpdateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}