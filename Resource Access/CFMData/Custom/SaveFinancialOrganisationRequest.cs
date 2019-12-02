using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData.Custom
{
    public class SaveFinancialOrganisationRequest
    {
        public AddressDTO PhysicalAddress { get; set; }
        public FinAdministratorDTO finAdministratorDto { get; set; }

    }
}
