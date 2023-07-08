﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestRelationship.Models;

#nullable disable

namespace TestRelationship.Migrations
{
    [DbContext(typeof(DbContextTestRelationship))]
    [Migration("20230707114046_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestRelationship.Models.MessageModel", b =>
                {
                    b.Property<int>("MessageModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageModelId"));

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    b.Property<DateTimeOffset>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIMEOFFSET")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<int>("MessageState")
                        .HasColumnType("int");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("ReciverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIMEOFFSET")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.HasKey("MessageModelId");

                    b.HasIndex("ReciverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("TestRelationship.Models.UserModel", b =>
                {
                    b.Property<int>("UserModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserModelId"));

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    b.Property<short>("Age")
                        .HasColumnType("SMALLINT");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("DATETIME");

                    b.Property<DateTimeOffset>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIMEOFFSET")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR");

                    b.Property<bool?>("IsDeveloper")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIMEOFFSET")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.HasKey("UserModelId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TestRelationship.Models.MessageModel", b =>
                {
                    b.HasOne("TestRelationship.Models.UserModel", "Reciver")
                        .WithMany("ReceiveMessageList")
                        .HasForeignKey("ReciverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TestRelationship.Models.UserModel", "Sender")
                        .WithMany("SendMessageList")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Reciver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TestRelationship.Models.UserModel", b =>
                {
                    b.Navigation("ReceiveMessageList");

                    b.Navigation("SendMessageList");
                });
#pragma warning restore 612, 618
        }
    }
}
