using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData.Custom
{
    public class UserAccessMappingRequest
    {
        public bool IsFinAdmin { get; set; }
        public int FinAdminId { get; set; }
        public ApplicationUserDTO User { get; set; }

        public AddressDTO PhysicalAddress { get; set; }

        public AddressDTO PostalAddress { get; set; }

        public bool IsResettingPassword { get; set; }

    public string BusinessEntitieIDs { get; set; }

    public string BusinessDivisionIDs { get; set; }

    public string BusinessAreaIDs { get; set; }

    public string HomeIDs { get; set; }

    public string ClientIDs { get; set; }


    // public List<>
  }

  public class AccessMappings
    {
        public int ID { get; set; }

        public bool IsActive { get; set; }
    }
}
