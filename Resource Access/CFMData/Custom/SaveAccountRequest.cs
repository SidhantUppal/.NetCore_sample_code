using System;
using System.Collections.Generic;
using System.Text;

namespace CFMData.Custom
{
    public class SaveAccountRequest
    {
        // public int GLEntityID { get; set; }

        public List<GLAccountDTO> Accounts { get; set; }
    }

    public class AccountData
    {
        //public GLAccountDTO GlAccount { get; set; }

        //public BankAccountDTO BankAccount { get; set; }

        public string AccountCode { get; set; }

        public string AccountType { get; set; }

        public int? GLAccountID { get; set; }

        public string GLAccountName { get; set; }

        public string BankName { get; set; }

        public string BSB { get; set; }

        public string BankAccountName { get; set; }

        public int BSBDetailID { get; set; }

        public int GLAccountTypeID { get; set; }

        public string AccountNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
