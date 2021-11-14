﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspDocker.Models;

namespace aspDocker.Migrations
{
    [DbContext(typeof(NoteContext))]
    partial class NoteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("aspDocker.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NoteBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}