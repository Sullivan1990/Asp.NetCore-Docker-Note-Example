using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspDocker.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteBody { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
