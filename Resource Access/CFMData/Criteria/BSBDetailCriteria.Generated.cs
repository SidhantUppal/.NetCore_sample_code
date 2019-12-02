﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'BSBDetail.cs'.
//
//     Template: Criteria.Generated.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


 

namespace CFMData
{
    [Serializable]
    public partial class BSBDetailCriteria 
    {
        private readonly Dictionary<string, object> _bag = new Dictionary<string, object>();
        
        #region Constructors

        public BSBDetailCriteria(){}

        public BSBDetailCriteria(System.Int32 bSBDetailID)
        {
            BSBDetailID = bSBDetailID;
        }

        #endregion

        #region Public Properties

        #region Read-Write

        public System.Int32 BSBDetailID
        {
            get { return GetValue<System.Int32>("BSBDetailID"); }
            set { _bag["BSBDetailID"] = value; }
        }

        public System.String Bsb
        {
            get { return GetValue<System.String>("BSB"); }
            set { _bag["BSB"] = value; }
        }

        public System.String BankCode
        {
            get { return GetValue<System.String>("BankCode"); }
            set { _bag["BankCode"] = value; }
        }

        public System.String BSBName
        {
            get { return GetValue<System.String>("BSBName"); }
            set { _bag["BSBName"] = value; }
        }

        public System.String Address
        {
            get { return GetValue<System.String>("Address"); }
            set { _bag["Address"] = value; }
        }

        public System.String Suburb
        {
            get { return GetValue<System.String>("Suburb"); }
            set { _bag["Suburb"] = value; }
        }

        public System.String State
        {
            get { return GetValue<System.String>("State"); }
            set { _bag["State"] = value; }
        }

        public System.String PostCode
        {
            get { return GetValue<System.String>("PostCode"); }
            set { _bag["PostCode"] = value; }
        }

        public System.String PaymentSystems
        {
            get { return GetValue<System.String>("PaymentSystems"); }
            set { _bag["PaymentSystems"] = value; }
        }

        #endregion
        
        #region Read-Only

        public bool BsbHasValue
        {
            get { return _bag.ContainsKey("BSB"); }
        }

        public bool BankCodeHasValue
        {
            get { return _bag.ContainsKey("BankCode"); }
        }

        public bool BSBNameHasValue
        {
            get { return _bag.ContainsKey("BSBName"); }
        }

        public bool AddressHasValue
        {
            get { return _bag.ContainsKey("Address"); }
        }

        public bool SuburbHasValue
        {
            get { return _bag.ContainsKey("Suburb"); }
        }

        public bool StateHasValue
        {
            get { return _bag.ContainsKey("State"); }
        }

        public bool PostCodeHasValue
        {
            get { return _bag.ContainsKey("PostCode"); }
        }

        public bool PaymentSystemsHasValue
        {
            get { return _bag.ContainsKey("PaymentSystems"); }
        }

        /// <summary>
        /// Returns a list of all the modified properties and values.
        /// </summary>
        public Dictionary<string, object> StateBag
        {
            get
            {
                return _bag;
            }
        }

        /// <summary>
        /// Returns a list of all the modified properties and values.
        /// </summary>
        public string TableFullName
        {
            get
            {
                return "[dbo].[BSBDetail]";
            }
        }

        #endregion

        #endregion

        #region Overrides
        
        public  string ToString()
        {
            var result = String.Empty;
            var cancel = false;
            
            OnToString(ref result, ref cancel);
            if(cancel && !String.IsNullOrEmpty(result))
                return result;
            
            if (_bag.Count == 0)
                return "No criterion was specified.";

            foreach (KeyValuePair<string, object> key in _bag)
            {
                result += String.Format("[{0}] = '{1}' AND ", key.Key, key.Value);
            }

            return result.Remove(result.Length - 5, 5);
        }

        #endregion

        #region Private Methods
        private T GetValue<T>(string name)
        {
            object value;
            if (_bag.TryGetValue(name, out value))
                return (T) value;
        
            return default(T);
        }
        
        #endregion
        
        #region Partial Methods
        
        partial void OnToString(ref string result, ref bool cancel);
        
        #endregion
        
    }
}