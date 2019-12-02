﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//       Changes to this template will not be lost.
//
//     Template: EditableRoot.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using CFMData.Custom;


namespace CFMData
{
    /// <summary>
    /// The ApplicationUser class is a editable root class.
    /// </summary>
    public partial class ApplicationUser
    {
        private System.Boolean _ForceChangePasswordProperty;
        public System.Boolean ForceChangePassword
        {
            get { return _ForceChangePasswordProperty; }
            set
            {

                _ForceChangePasswordProperty = value;
            }
        }
    #region Business Rules

    /// <summary>
    /// All custom rules need to be placed in this method.
    /// </summary>
    /// <returns>Return true to override the generated rules; If false generated rules will be run.</returns>
    protected bool AddBusinessValidationRules()
        {
            // TODO: add validation rules
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(MyProperty));

            return false;
        }

        #endregion

        public static ApplicationUser LoginUser(string userName, string password)
        {
            return new ApplicationUser().LoginUserInternal(userName, password);
        }

        private ApplicationUser LoginUserInternal(string userName, string password)
        {

            bool cancel = false;

            if (cancel) return null;
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_ApplicationUser_Login]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@p_LoginName", userName);
                    command.Parameters.AddWithValue("@p_Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        var rowParser = reader.GetRowParser<ApplicationUser>();
                        if (reader.Read())
                        {
                            return GetApplicationUser(rowParser, reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            OnFetched();
        }

        public static void ResetPassword(string userName, int applicationUserID)
        {
            new ApplicationUser().ResetPasswordInternal(userName, applicationUserID);
        }

        private void ResetPasswordInternal(string userName, int applicationUserID)
        {
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_ApplicationUser_ResetPasswordRequest]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@p_ApplicationUserID", applicationUserID);

                    command.Parameters.AddWithValue("@p_LoginName", userName);

                    command.ExecuteNonQuery();

                }
            }
            OnFetched();
        }

        public static void SendActiveCheck(int applicationUserID, int updatedByUserID)
        {
            new ApplicationUser().SendActiveCheckInternal(applicationUserID, updatedByUserID);
        }

        private void SendActiveCheckInternal(int applicationUserID, int updatedByUserID)
        {
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_ApplicationUser_SendActiveCheck]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@p_ApplicationUserID", applicationUserID);                    

                    command.Parameters.AddWithValue("@p_UpdateByUserID", updatedByUserID);

                    command.ExecuteNonQuery();

                }
            }
            OnFetched();
        }

        public static void ChangePassword(string resetToken, string password)
        {
            new ApplicationUser().ChangePasswordInternal(resetToken, password);
        }

        private void ChangePasswordInternal(string resetToken, string password)
        {
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_ApplicationUser_ResetChangePassword]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@p_PasswordResetToken", resetToken);
                    command.Parameters.AddWithValue("@p_Password", password);

                    command.ExecuteNonQuery();

                }
            }
            OnFetched();
        }





        public static ApplicationUser UpdatePassword(string userName, string currentPassword, string password)
        {
            return new ApplicationUser().UpdatePasswordInternal(userName, currentPassword, password);
        }

        private ApplicationUser UpdatePasswordInternal(string userName, string currentPassword, string password)
        {
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_ApplicationUser_ChangePassword]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_loginName", userName);
                    command.Parameters.AddWithValue("@p_currentPassword", currentPassword);
                    command.Parameters.AddWithValue("@p_Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        var rowParser = reader.GetRowParser<ApplicationUser>();
                        if (reader.Read())
                        {
                            return GetApplicationUser(rowParser, reader);
                        }
                        else
                            throw new Exception(String.Format("The record was not found in 'dbo.ApplicationUser' using the following criteria:"));
                    }

                }
            }
            OnFetched();
        }

        public bool IsResettingPassword { get; set; }


        private bool HasAddress(AddressDTO address)
        {
            if (address == null)
            {
                return false;
            }
            return !string.IsNullOrEmpty(address.PostCode)
                   || !string.IsNullOrEmpty(address.Suburb)
                   || !string.IsNullOrEmpty(address.Street)
                   || address.CountryID != 0
                   || address.StateID != 0;
        }




        private void AddAddressParams(SqlCommand command, AddressDTO address, string prefix)
        {
            bool hasPhysicalAddress = HasAddress(address);
            Address physicalAddress = null;
            if (hasPhysicalAddress)
            {

                command.Parameters.AddWithValue("@p_" + prefix + "Street", ADOHelper.NullCheck(address.Street));
                command.Parameters.AddWithValue("@p_" + prefix + "Suburb", ADOHelper.NullCheck(address.Suburb));
                command.Parameters.AddWithValue("@p_" + prefix + "StateID", ADOHelper.NullCheck(address.StateID));
                command.Parameters.AddWithValue("@p_" + prefix + "CountryID", ADOHelper.NullCheck(address.CountryID));
                command.Parameters.AddWithValue("@p_" + prefix + "PostCode", ADOHelper.NullCheck(address.PostCode));
                command.Parameters.AddWithValue("@p_" + prefix + "AddressID", ADOHelper.NullCheck(address.AddressID));



            }
        }
        public void CustomSave(UserAccessMappingRequest data, string md5Password)
        {

            bool cancel = false;
            OnUpdating(ref cancel);
            data.User.CustomCopyDTO(this);
            if (data.User.ApplicationUserID <= 0)
            {

                data.User.Password = md5Password;
            }
            else
            {
                if (data.IsResettingPassword)
                {
                    data.User.Password = md5Password;
                }
            }





            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_ApplicationUser_CustomUpdate]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ApplicationUserID", data.User.ApplicationUserID);
                    if (data.User.ApplicationUserID <= 0)
                    {
                        command.Parameters["@p_ApplicationUserID"].Direction = ParameterDirection.Output;
                    }

                    command.Parameters.AddWithValue("@p_LoginName", data.User.LoginName);
                    command.Parameters.AddWithValue("@p_Password", data.User.Password);
                    command.Parameters.AddWithValue("@p_FirstName", data.User.FirstName);
                    command.Parameters.AddWithValue("@p_LastName", ADOHelper.NullCheck(data.User.LastName));
                    command.Parameters.AddWithValue("@p_EmailAddress", ADOHelper.NullCheck(data.User.EmailAddress));
                    command.Parameters.AddWithValue("@p_MobilePhone", ADOHelper.NullCheck(data.User.MobilePhone));
                    command.Parameters.AddWithValue("@p_WorkPhone", ADOHelper.NullCheck(data.User.WorkPhone));
                    command.Parameters.AddWithValue("@p_IsActive", data.User.IsActive);
                    command.Parameters.AddWithValue("@p_PasswordResetNeeded", data.User.PasswordResetNeeded);
                    command.Parameters.AddWithValue("@p_PasswordResetToken", ADOHelper.NullCheck(data.User.PasswordResetToken));
                    command.Parameters.AddWithValue("@p_PasswordResetTokenExpiry", ADOHelper.NullCheck(data.User.PasswordResetTokenExpiry));
                    command.Parameters.AddWithValue("@p_MustChangePassword", data.User.MustChangePassword);
                    command.Parameters.AddWithValue("@p_ApplicationRoleID", ADOHelper.NullCheck(data.User.ApplicationRoleID));

                    command.Parameters.AddWithValue("@p_StatementDeliveryOptionID", ADOHelper.NullCheck(data.User.StatementDeliveryOptionID));

                    command.Parameters.AddWithValue("@p_SameAsPhysicalAddress", data.User.SameAsPhysicalAddress);

                    command.Parameters.AddWithValue("@p_IsResettingPassword", data.IsResettingPassword);

                    command.Parameters.AddWithValue("@p_ActionBy", ADOHelper.NullCheck(data.User.UpdatedBy));
                    AddAddressParams(command, data.PhysicalAddress, "Physical");
                    AddAddressParams(command, data.PostalAddress, "Postal");
                    //command.Parameters.AddWithValue("@p_PhysicalAddressID", ADOHelper.NullCheck(data.User.PhysicalAddressID));
                    //command.Parameters.AddWithValue("@p_PostalAddressID", ADOHelper.NullCheck(data.User.PostalAddressID));
                    command.Parameters.AddWithValue("@p_BusinessAreaIDs", ADOHelper.NullCheck(data.BusinessAreaIDs));
                    command.Parameters.AddWithValue("@p_BusinessDivisionIDs", ADOHelper.NullCheck(data.BusinessDivisionIDs));
                    command.Parameters.AddWithValue("@p_BusinessEntitieIDs", ADOHelper.NullCheck(data.BusinessEntitieIDs));
                    command.Parameters.AddWithValue("@p_HomeIDs", ADOHelper.NullCheck(data.HomeIDs));
                    command.Parameters.AddWithValue("@p_ClientIDs", ADOHelper.NullCheck(data.ClientIDs));


                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    _applicationUserIDProperty = (System.Int32)command.Parameters["@p_ApplicationUserID"].Value;
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                }
                //UpdateChildren(this, connection);
                //FieldManager.UpdateChildren(this, connection);
            }

            OnUpdated();
        }


    }
}