using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspDocker.ToolModels
{
    /// <summary>
    /// A Utility class to handle various parameters recieved when querying the Note Endpoints
    /// </summary>
    public class NoteFilterModel
    {
        
        /// <summary>
        /// The Page to display - used by the Skip method, with the provided value - 1 multiplied by the provided items per page
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// The number of items to display per page, Default of 10
        /// </summary>
        public int? ItemsPerPage { get; set; } = 10;
        /// <summary>
        /// the UserId to show notes for, if blank will show notes for all users
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Text to filter Note titles by
        /// </summary>
        public string NoteTitleContains { get; set; }
        /// <summary>
        /// Text to filter Note bodies by
        /// </summary>
        public string NoteTextContains { get; set; }

    }
}
