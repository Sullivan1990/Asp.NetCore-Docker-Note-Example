using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace aspDocker.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }
    }

    public class Note{
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteBody { get; set; }
    }
}
