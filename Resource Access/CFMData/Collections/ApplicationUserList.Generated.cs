﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'ApplicationUserList.cs'.
//
//     Template: EditableRootList.Generated.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
 
namespace CFMData
{
    [Serializable]
    public partial class ApplicationUserList : List< ApplicationUser>
    {    
        private List<ApplicationUserDTO> _currentDto =null; 
        public List<ApplicationUserDTO> CurrentDTO
        {
            get 
            {
                if (_currentDto==null)
                {
                    _currentDto=new List<ApplicationUserDTO>();
                    foreach (ApplicationUser entity in this)
                    {
                        _currentDto.Add(entity.CurrentDTO);
                    }
                }
                return _currentDto;
			}
            
        }
        #region Contructor(s)

        public ApplicationUserList()
        { 
       //     AllowNew = true;
        }

        #endregion

       

        #region Synchronous Factory Methods 

        /// <summary>
        /// Creates a new object of type <see cref="ApplicationUserList"/>. 
        /// </summary>
        /// <returns>Returns a newly instantiated collection of type <see cref="ApplicationUserList"/>.</returns>
        public static ApplicationUserList NewList()
        {
            return new ApplicationUserList();
        }      

        /// <summary>
        /// Returns a <see cref="ApplicationUserList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="applicationUserID">No additional detail available.</param>
        /// <returns>A <see cref="ApplicationUserList"/> object of the specified criteria.</returns>
        public static ApplicationUserList GetByApplicationUserID(System.Int32 applicationUserID)
        {
            var criteria = new ApplicationUserCriteria{ApplicationUserID = applicationUserID};
            
            
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
        }

        /// <summary>
        /// Returns a <see cref="ApplicationUserList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="physicalAddressID">No additional detail available.</param>
        /// <returns>A <see cref="ApplicationUserList"/> object of the specified criteria.</returns>
        public static ApplicationUserList GetByPhysicalAddressID(System.Int32? physicalAddressID)
        {
            var criteria = new ApplicationUserCriteria{};
                            if(physicalAddressID.HasValue) criteria.PhysicalAddressID = physicalAddressID.Value;
            
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
        }

        /// <summary>
        /// Returns a <see cref="ApplicationUserList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="postalAddressID">No additional detail available.</param>
        /// <returns>A <see cref="ApplicationUserList"/> object of the specified criteria.</returns>
        public static ApplicationUserList GetByPostalAddressID(System.Int32? postalAddressID)
        {
            var criteria = new ApplicationUserCriteria{};
                            if(postalAddressID.HasValue) criteria.PostalAddressID = postalAddressID.Value;
            
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
        }

        /// <summary>
        /// Returns a <see cref="ApplicationUserList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="applicationRoleID">No additional detail available.</param>
        /// <returns>A <see cref="ApplicationUserList"/> object of the specified criteria.</returns>
        public static ApplicationUserList GetByApplicationRoleID(System.Int32? applicationRoleID)
        {
            var criteria = new ApplicationUserCriteria{};
                            if(applicationRoleID.HasValue) criteria.ApplicationRoleID = applicationRoleID.Value;
            
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
        }

        /// <summary>
        /// Returns a <see cref="ApplicationUserList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="updatedBy">No additional detail available.</param>
        /// <returns>A <see cref="ApplicationUserList"/> object of the specified criteria.</returns>
        public static ApplicationUserList GetByUpdatedBy(System.Int32? updatedBy)
        {
            var criteria = new ApplicationUserCriteria{};
                            if(updatedBy.HasValue) criteria.UpdatedBy = updatedBy.Value;
            
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
        }

        /// <summary>
        /// Returns a <see cref="ApplicationUserList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="statementDeliveryOptionID">No additional detail available.</param>
        /// <returns>A <see cref="ApplicationUserList"/> object of the specified criteria.</returns>
        public static ApplicationUserList GetByStatementDeliveryOptionID(System.Int32? statementDeliveryOptionID)
        {
            var criteria = new ApplicationUserCriteria{};
                            if(statementDeliveryOptionID.HasValue) criteria.StatementDeliveryOptionID = statementDeliveryOptionID.Value;
            
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
        }

        public static ApplicationUserList GetByCriteria(ApplicationUserCriteria criteria)
        {
          return  new ApplicationUserList().DataPortal_Fetch(criteria);
//            return DataPortal.Fetch<ApplicationUserList>(criteria);
        }

        public static ApplicationUserList GetAll()
        {
          return  new ApplicationUserList().DataPortal_Fetch(new ApplicationUserCriteria());
            //return DataPortal.Fetch<ApplicationUserList>(new ApplicationUserCriteria());
        }

        #endregion

        #region Asynchronous Factory Methods
     

     

     

     

     

     

     
 
        #endregion

        #region DataPortal partial methods

        /// <summary>
        /// CodeSmith generated stub method that is called when creating the child <see cref="ApplicationUser"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnCreating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="ApplicationUser"/> object has been created. 
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// CodeSmith generated stub method that is called when fetching the child <see cref="ApplicationUser"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="ApplicationUserCriteria"/> object containing the criteria of the object to fetch.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        partial void OnFetching(ApplicationUserCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="ApplicationUser"/> object has been fetched. 
        /// </summary>
        partial void OnFetched();

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="ApplicationUser"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="ApplicationUser"/> object. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        //partial void OnMapping(SafeDataReader reader, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="ApplicationUser"/> object has been mapped. 
        /// </summary>
        partial void OnMapped();

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the <see cref="ApplicationUser"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnUpdating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="ApplicationUser"/> object has been updated. 
        /// </summary>
        partial void OnUpdated();
       // partial void OnAddNewCore(ref ApplicationUser item, ref bool cancel);

        #endregion

    }
}