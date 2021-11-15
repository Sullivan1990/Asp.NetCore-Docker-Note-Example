using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspDocker.Models
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Note> Notes { get; set; }

    }
}
