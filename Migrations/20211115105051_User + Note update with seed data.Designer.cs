﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspDocker.Models;

namespace aspDocker.Migrations
{
    [DbContext(typeof(NoteContext))]
    [Migration("20211115105051_User + Note update with seed data")]
    partial class UserNoteupdatewithseeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("aspDocker.Models.ApplicationUser", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ApplicationUserId = 1,
                            PasswordHash = "$2b$10$DgDEbtTUWmGl4l0Dei4fHeg6l1latha415M2Uld0eXrdzjDY63gTO",
                            UserName = "Steve"
                        });
                });

            modelBuilder.Entity("aspDocker.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("NoteBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            NoteId = 1,
                            ApplicationUserId = 1,
                            NoteBody = "The body of the first note",
                            NoteTitle = "An Example Note Title"
                        },
                        new
                        {
                            NoteId = 2,
                            ApplicationUserId = 1,
                            NoteBody = "The body of the second note",
                            NoteTitle = "Another Example Note Title"
                        });
                });

            modelBuilder.Entity("aspDocker.Models.Note", b =>
                {
                    b.HasOne("aspDocker.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Notes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("aspDocker.Models.ApplicationUser", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
