using System;

namespace CFMCommon
{
    [Serializable]
    public enum UserClaims
    {
        
        UserID,
        Roles
  }
    [Serializable]
  public enum SystemRoleTypeEnum
    {
        CFMAdmin,
        Supervisor,
        FinancialAdministrator,
        CFMUser
  }
  [Serializable]
  public enum SystemConfigEnum
  {
      ApplicationURL,
      SmtpServerPort,
      SmtpServer,
      SMTPServerAuthPassword,
      SMTPServerAuthUserName,
      SMTPEnableSSL
  }
}
