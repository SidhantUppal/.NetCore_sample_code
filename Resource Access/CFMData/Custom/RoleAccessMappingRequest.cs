using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData.Custom
{
    public class RoleAccessMappingRequest
    {
        public ApplicationRoleDTO Role { get; set; }

        public string BusinessEntityIDs { get; set; }

        public string BusinessDivisionIDs { get; set; }

        public string BusinessAreaIDs { get; set; }

        public string HomeIDs { get; set; }

        public string ClientIDs { get; set; }
    }
}
