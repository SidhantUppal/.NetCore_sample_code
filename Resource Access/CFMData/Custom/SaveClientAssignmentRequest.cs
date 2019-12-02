using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData.Custom
{
    public class SaveClientAssignmentRequest
    {
        public int ClientID { get; set; }

        public int ClientAssignmentEntityID { get; set; }

        public int SourceEntityTypeID { get; set; }

        public int SourceEntityID { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }
    }
}
