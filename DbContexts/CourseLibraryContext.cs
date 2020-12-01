using CourseApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.DbContexts
{
    public class CourseLibraryContext : DbContext
    {
        public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options)
            :base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        // seed the database with dummy data
        //using an overide method "onModelCreating"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(

                new Author()
                {
                    ID = 1,
                    FirstName = "Berry",
                    LastName = "Griffin Beak  Eldricth",
                    DateOfBirth = new DateTime(1650, 5, 11),
                    MainCategory = "Ships"
                },
                new Author()
                {
                    ID = 2,
                    FirstName = "Nancy",
                    LastName = "Swashbuckler Rye",
                    DateOfBirth = new DateTime(1668, 5, 21),
                    MainCategory = "Rum"

                },
                 new Author()
                 {
                     ID = 3,
                     FirstName = "Eli",
                     LastName = "Ivory Bones Sweet",
                     DateOfBirth = new DateTime(1701, 12, 16),
                     MainCategory = "Singing"
                 },
                new Author()
                {
                    ID = 4,
                    FirstName = "Arnold",
                    LastName = "The Unseen Stafford",
                    DateOfBirth = new DateTime(1702, 3, 6),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    ID = 5,
                    FirstName = "Seabury",
                    LastName = "Toxic Reyson",
                    DateOfBirth = new DateTime(1690, 11, 23),
                    MainCategory = "Maps"
                },
                new Author()
                {
                    ID = 6,
                    FirstName = "Rutherford",
                    LastName = "Fearless Cloven",
                    DateOfBirth = new DateTime(1723, 4, 5),
                    MainCategory = "General debauchery"
                },
                new Author()
                {
                    ID = 7,
                    FirstName = "Atherton",
                    LastName = "Crow Ridley",
                    DateOfBirth = new DateTime(1721, 10, 11),
                    MainCategory = "Rum"
                },
                new Author()
                {
                    ID = 8,
                    FirstName = "Huxford",
                    LastName = "The Hawk Morris",
                    DateOfBirth = new DateTime(1969, 8, 11),
                    MainCategory = "Maps"
                },
                 new Author()
                 {
                     ID = 9,
                     FirstName = "Dwennon",
                     LastName = "Rigger Quye",
                     DateOfBirth = new DateTime(1972, 1, 8),
                     MainCategory = "Maps"
                 },
                 new Author()
                 {
                     ID = 10,
                     FirstName = "Rushford",
                     LastName = "Subtle Asema",
                     DateOfBirth = new DateTime(1982, 5, 5),
                     MainCategory = "Rum"
                 },
                 new Author()
                 {
                     ID = 11,
                     FirstName = "Hagley",
                     LastName = "Imposter Grendel",
                     DateOfBirth = new DateTime(1976, 7, 12),
                     MainCategory = "Singing"
                 },
                 new Author()
                 {
                     ID = 12,
                     FirstName = "Mabel",
                     LastName = "Barnacle Grendel",
                     DateOfBirth = new DateTime(1977, 2, 8),
                     MainCategory = "Maps"
                 }
                );

            modelBuilder.Entity<Course>().HasData(

                new Course()
                {
                    ID = 1,
                    AuthorId = 1,
                    Title = "Commandeering a Ship Without Getting Caught",
                    Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder In this course, the author provides tips to avoid, or," +
                    " if needed, overthrow pirate mutiny"

                },

                 new Course
                 {
                     ID = 2,
                     AuthorId = 2,
                     Title = "Overthrowing Mutiny",
                     Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
                 },

                  new Course
                  {
                      ID = 3,
                      AuthorId = 3,
                      Title = "Overthrowing Mutiny",
                      Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
                  },

                   new Course
                   {
                       ID = 4,
                       AuthorId = 3,
                       Title = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                       Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.In this course, the" +
                       " author provides tips to avoid, or, if needed, overthrow pirate mutiny"


                   },

                    new Course
                    {
                        ID = 5,
                        AuthorId = 4,
                        Title = "Singalong Pirate Hits",
                        Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like " +
                        "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny"

                    },

                     new Course
                     {
                         ID = 6,
                         AuthorId = 4,
                         Title = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                         Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.In this course, the author provides tips to avoid" +
                         ", or, if needed, overthrow pirate mutiny"
                     },

                      new Course
                      {
                          ID = 7,
                          AuthorId = 9,
                          Title = "Overthrowing Mutiny",
                          Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.In this course, the author provides" +
                          " tips to avoid, or, if needed, overthrow pirate mutiny"
                      },

                       new Course
                       {
                           ID = 8,
                           AuthorId = 10,
                           Title = " Mutiny",
                           Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny. In this course, " +
                           "the author provides tips to avoid, or, if needed, overthrow pirate mutiny"
                       }
                );
        }
    }
}
