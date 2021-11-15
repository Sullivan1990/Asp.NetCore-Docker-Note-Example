using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCrypt;


namespace aspDocker.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<ApplicationUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    ApplicationUserId = 1,
                    UserName = "Steve",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("abc_1234"),
                });

            builder.Entity<Note>().HasData(
                new Note
                {
                    NoteId = 1,
                    NoteTitle = "An Example Note Title",
                    NoteBody = "The body of the first note",
                    ApplicationUserId = 1
                },
                new Note
                {
                    NoteId = 2,
                    NoteTitle = "Another Example Note Title",
                    NoteBody = "The body of the second note",
                    ApplicationUserId = 1
                });
        }

    }


}
