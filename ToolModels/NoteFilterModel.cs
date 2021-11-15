using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspDocker.ToolModels
{
    public class NoteFilterModel
    {
        
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public int? ItemsPerPage { get; set; } = 10;
        public int? UserId { get; set; }
        public string NoteTitleContains { get; set; }
        public string NoteTextContains { get; set; }

    }
}
