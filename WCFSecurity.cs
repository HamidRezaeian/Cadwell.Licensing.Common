// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.WCFSecurity
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class WCFSecurity
  {
    internal static readonly string _Password = "{D6AF5025-9456-42C1-813E-576D6EE1A99C}";
    internal static readonly string _Thumbprint = "433E561CE5945566CDA03B6534FD2F5D624CCDEA";

    public static void SetClientCredentials(ClientCredentials credentials, string userName = "admin")
    {
      credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
      credentials.ServiceCertificate.Authentication.CustomCertificateValidator = (X509CertificateValidator) new WCFSecurity.CustomCertificateValidator();
      credentials.UserName.UserName = userName;
      credentials.UserName.Password = WCFSecurity._Password;
      Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Cadwell.Licensing.Common.Cadwell.pfx");
      byte[] numArray = new byte[manifestResourceStream.Length];
      manifestResourceStream.Read(numArray, 0, (int) manifestResourceStream.Length);
      X509Certificate2 x509Certificate2 = new X509Certificate2(numArray, "", X509KeyStorageFlags.MachineKeySet);
      credentials.ClientCertificate.Certificate = x509Certificate2;
    }

    public static void ConfigureServerBehavior(ref ServiceHost host)
    {
      ServiceCredentials serviceCredentials = host.Description.Behaviors.Find<ServiceCredentials>() ?? new ServiceCredentials();
      serviceCredentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
      serviceCredentials.UserNameAuthentication.CustomUserNamePasswordValidator = (UserNamePasswordValidator) new WCFSecurity.CustomUserNameValidator();
      serviceCredentials.ClientCertificate.Authentication.CustomCertificateValidator = (X509CertificateValidator) new WCFSecurity.CustomCertificateValidator();
      serviceCredentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
      host.Description.Behaviors.Add((IServiceBehavior) serviceCredentials);
      Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Cadwell.Licensing.Common.Cadwell.pfx");
      byte[] numArray = new byte[manifestResourceStream.Length];
      manifestResourceStream.Read(numArray, 0, (int) manifestResourceStream.Length);
      X509Certificate2 x509Certificate2 = new X509Certificate2(numArray, "");
      host.Credentials.ServiceCertificate.Certificate = x509Certificate2;
      ServiceDebugBehavior serviceDebugBehavior = host.Description.Behaviors.Find<ServiceDebugBehavior>();
      if (serviceDebugBehavior == null)
      {
        serviceDebugBehavior = new ServiceDebugBehavior();
        host.Description.Behaviors.Add((IServiceBehavior) serviceDebugBehavior);
      }
      serviceDebugBehavior.IncludeExceptionDetailInFaults = true;
      ServiceSecurityAuditBehavior securityAuditBehavior = host.Description.Behaviors.Find<ServiceSecurityAuditBehavior>();
      if (securityAuditBehavior == null)
      {
        securityAuditBehavior = new ServiceSecurityAuditBehavior();
        host.Description.Behaviors.Add((IServiceBehavior) securityAuditBehavior);
      }
      securityAuditBehavior.AuditLogLocation = AuditLogLocation.Application;
      securityAuditBehavior.ServiceAuthorizationAuditLevel = AuditLevel.Failure;
      securityAuditBehavior.MessageAuthenticationAuditLevel = AuditLevel.Failure;
      ServiceThrottlingBehavior throttlingBehavior = new ServiceThrottlingBehavior()
      {
        MaxConcurrentCalls = 500,
        MaxConcurrentInstances = 500,
        MaxConcurrentSessions = 500
      };
      host.Description.Behaviors.Add((IServiceBehavior) throttlingBehavior);
    }

    private class CustomUserNameValidator : UserNamePasswordValidator
    {
      public override void Validate(string userName, string password)
      {
        if (userName == null)
          throw new ArgumentNullException(userName);
        if (password == null)
          throw new ArgumentNullException(userName);
        if (!(password == WCFSecurity._Password))
          throw new FaultException("Unknown Username or Incorrect Password");
      }
    }

    private class CustomCertificateValidator : X509CertificateValidator
    {
      public override void Validate(X509Certificate2 certificate)
      {
        if (certificate.Thumbprint != WCFSecurity._Thumbprint)
          throw new SecurityTokenValidationException("Client certificate is not trusted");
      }
    }
  }
}
