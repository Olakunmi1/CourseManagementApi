﻿// <auto-generated />
using System;
using CourseApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseApi.Migrations
{
    [DbContext(typeof(CourseLibraryContext))]
    [Migration("20201205142624_SystemErrorLog")]
    partial class SystemErrorLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CourseApi.Entities.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MainCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateOfBirth = new DateTimeOffset(new DateTime(1650, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Berry",
                            LastName = "Griffin Beak  Eldricth",
                            MainCategory = "Ships"
                        },
                        new
                        {
                            ID = 2,
                            DateOfBirth = new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Nancy",
                            LastName = "Swashbuckler Rye",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            ID = 3,
                            DateOfBirth = new DateTimeOffset(new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Eli",
                            LastName = "Ivory Bones Sweet",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            ID = 4,
                            DateOfBirth = new DateTimeOffset(new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Arnold",
                            LastName = "The Unseen Stafford",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            ID = 5,
                            DateOfBirth = new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Seabury",
                            LastName = "Toxic Reyson",
                            MainCategory = "Maps"
                        },
                        new
                        {
                            ID = 6,
                            DateOfBirth = new DateTimeOffset(new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Rutherford",
                            LastName = "Fearless Cloven",
                            MainCategory = "General debauchery"
                        },
                        new
                        {
                            ID = 7,
                            DateOfBirth = new DateTimeOffset(new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Atherton",
                            LastName = "Crow Ridley",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            ID = 8,
                            DateOfBirth = new DateTimeOffset(new DateTime(1969, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Huxford",
                            LastName = "The Hawk Morris",
                            MainCategory = "Maps"
                        },
                        new
                        {
                            ID = 9,
                            DateOfBirth = new DateTimeOffset(new DateTime(1972, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Dwennon",
                            LastName = "Rigger Quye",
                            MainCategory = "Maps"
                        },
                        new
                        {
                            ID = 10,
                            DateOfBirth = new DateTimeOffset(new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Rushford",
                            LastName = "Subtle Asema",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            ID = 11,
                            DateOfBirth = new DateTimeOffset(new DateTime(1976, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Hagley",
                            LastName = "Imposter Grendel",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            ID = 12,
                            DateOfBirth = new DateTimeOffset(new DateTime(1977, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Mabel",
                            LastName = "Barnacle Grendel",
                            MainCategory = "Maps"
                        });
                });

            modelBuilder.Entity("CourseApi.Entities.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorId = 1,
                            Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny",
                            Title = "Commandeering a Ship Without Getting Caught"
                        },
                        new
                        {
                            ID = 2,
                            AuthorId = 2,
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.",
                            Title = "Overthrowing Mutiny"
                        },
                        new
                        {
                            ID = 3,
                            AuthorId = 3,
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.",
                            Title = "Overthrowing Mutiny"
                        },
                        new
                        {
                            ID = 4,
                            AuthorId = 3,
                            Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny",
                            Title = "Avoiding Brawls While Drinking as Much Rum as You Desire"
                        },
                        new
                        {
                            ID = 5,
                            AuthorId = 4,
                            Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny",
                            Title = "Singalong Pirate Hits"
                        },
                        new
                        {
                            ID = 6,
                            AuthorId = 4,
                            Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny",
                            Title = "Avoiding Brawls While Drinking as Much Rum as You Desire"
                        },
                        new
                        {
                            ID = 7,
                            AuthorId = 9,
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny",
                            Title = "Overthrowing Mutiny"
                        },
                        new
                        {
                            ID = 8,
                            AuthorId = 10,
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny. In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny",
                            Title = " Mutiny"
                        });
                });

            modelBuilder.Entity("CourseApi.Entities.SystemErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Transdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("error_messg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("error_source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("systemErrorLogs");
                });

            modelBuilder.Entity("CourseApi.Entities.Course", b =>
                {
                    b.HasOne("CourseApi.Entities.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("CourseApi.Entities.Author", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
