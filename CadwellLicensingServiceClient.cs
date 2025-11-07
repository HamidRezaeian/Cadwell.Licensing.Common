// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.CadwellLicensingServiceClient
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using Cadwell.Licensing.Common.Properties;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public class CadwellLicensingServiceClient : 
    ClientBase<ICadwellLicensingService>,
    ICadwellLicensingService
  {
    public static CadwellLicensingServiceClient Create(
      string transportProtocol,
      string serverName,
      int portNumber,
      string userName)
    {
      if (string.IsNullOrWhiteSpace(transportProtocol))
        throw new ArgumentException("The external licensing service transport protocol can NOT be null or whitespace.", nameof (transportProtocol));
      if (string.IsNullOrWhiteSpace(serverName))
        throw new ArgumentException("The external licensing service server name can NOT be null or whitespace.", nameof (serverName));
      if (string.IsNullOrWhiteSpace(userName))
        throw new ArgumentException("The user name  can NOT be null or whitespace.", nameof (userName));
      CadwellLicensingServiceClient licensingServiceClient = new CadwellLicensingServiceClient((Binding) WCFBindings.CreateEncryptedTcpBinding(TimeSpan.FromMinutes(1.0)), new EndpointAddress(new Uri(string.Format("{0}://{1}:{2}/ExternalLicensingService", (object) transportProtocol, (object) serverName, (object) portNumber)), (EndpointIdentity) new DnsEndpointIdentity("localhost"), new AddressHeaderCollection()));
      WCFSecurity.SetClientCredentials(licensingServiceClient.ClientCredentials, userName);
      return licensingServiceClient;
    }

    public static CadwellLicensingServiceClient Create(string userName, bool useLiveServer = true)
    {
      CadwellLicensingServiceClient licensingServiceClient = new CadwellLicensingServiceClient((Binding) WCFBindings.CreateEncryptedTcpBinding(TimeSpan.FromMinutes(1.0)), new EndpointAddress(new Uri(useLiveServer ? Settings.Default.ServerUrl : Settings.Default.TrainingServerUrl), (EndpointIdentity) new DnsEndpointIdentity("localhost"), new AddressHeaderCollection()));
      WCFSecurity.SetClientCredentials(licensingServiceClient.ClientCredentials, userName);
      return licensingServiceClient;
    }

    public ActivationInfo ActivateLicense(
      string licenseId,
      string computerId,
      string computerDescription,
      string productId)
    {
      if (!ArgumentValidator.LicenseIdIsValid(licenseId))
        throw new ArgumentException("The provided license ID is invalid.", nameof (licenseId));
      if (!ArgumentValidator.ComputerIdIsValid(computerId))
        throw new ArgumentException("The provided computer ID is invalid.", nameof (computerId));
      if (!ArgumentValidator.ComputerDescriptionIsValid(computerDescription))
        throw new ArgumentException("The provided service tag or serial number is invalid.", nameof (computerDescription));
      try
      {
        return this.Channel.ActivateLicense(licenseId, computerId, computerDescription, productId);
      }
      catch (FaultException<ArgumentFault> ex)
      {
        throw new ArgumentException(ex.Message, ex.Detail.ParameterName);
      }
    }

    public LicenseInfo GetLicense(string licenseId)
    {
      return ArgumentValidator.LicenseIdIsValid(licenseId) ? this.Channel.GetLicense(licenseId) : throw new ArgumentException("The provided license ID is invalid.", nameof (licenseId));
    }

    public List<LicenseInfo> GetLicenses(
      string productId = null,
      string customerNumber = null,
      string machineId = null,
      short? machineCount = null,
      string salesOrderNumber = null,
      bool? isDeactivated = null,
      bool? isDeleted = null)
    {
      return this.Channel.GetLicenses(productId, customerNumber, machineId, machineCount, salesOrderNumber, isDeactivated, isDeleted);
    }

    public FeatureUnlockInfo EmergencyUnlockLicense(
      string licenseId,
      string explanation,
      ICollection<short> featureIndexes)
    {
      if (!ArgumentValidator.LicenseIdIsValid(licenseId))
        throw new ArgumentException("The provided license ID is invalid.", nameof (licenseId));
      if (!ArgumentValidator.UnlockExplanationIsValid(explanation))
        throw new ArgumentException("The provided explanation is invalid.", nameof (explanation));
      try
      {
        return this.Channel.EmergencyUnlockLicense(licenseId, explanation, featureIndexes);
      }
      catch (FaultException<ArgumentFault> ex)
      {
        throw new ArgumentException(ex.Message, ex.Detail.ParameterName);
      }
    }

    public void UpdateLicensesComputerId(string licenseId, string newComputerId)
    {
      this.Channel.UpdateLicensesComputerId(licenseId, newComputerId);
    }

    public string GetHardwareLicenseFeatures(string serialNumber, string productId)
    {
      return this.Channel.GetHardwareLicenseFeatures(serialNumber, productId);
    }

    public string ActivateLicenseManually(
      string licenseId,
      string userCode,
      string computerDescription,
      string productId)
    {
      if (!ArgumentValidator.LicenseIdIsValid(licenseId))
        throw new ArgumentException("The provided license ID is invalid.", nameof (licenseId));
      if (!ArgumentValidator.UserCodeIsValid(userCode))
        throw new ArgumentException("The provided user code is invalid.", nameof (userCode));
      if (!ArgumentValidator.ComputerDescriptionIsValid(computerDescription))
        throw new ArgumentException("The provided service tag or serial number is invalid.", nameof (computerDescription));
      try
      {
        return this.Channel.ActivateLicenseManually(licenseId, userCode, computerDescription, productId);
      }
      catch (FaultException<ArgumentFault> ex)
      {
        throw new ArgumentException(ex.Message, ex.Detail.ParameterName);
      }
    }

    public string GenerateUpgradeCode(string licenseId, string userCode)
    {
      if (!ArgumentValidator.LicenseIdIsValid(licenseId))
        throw new ArgumentException("The provided license ID is invalid.", nameof (licenseId));
      if (!ArgumentValidator.UserCodeIsValid(userCode))
        throw new ArgumentException("The provided user code is invalid.", nameof (userCode));
      try
      {
        return this.Channel.GenerateUpgradeCode(licenseId, userCode);
      }
      catch (FaultException<ArgumentFault> ex)
      {
        throw new ArgumentException(ex.Message, ex.Detail.ParameterName);
      }
    }

    public string TransferLicense(string licenseId, string userCode, string computerDescription)
    {
      if (!ArgumentValidator.LicenseIdIsValid(licenseId))
        throw new ArgumentException("The provided license ID is invalid.", nameof (licenseId));
      if (!ArgumentValidator.UserCodeIsValid(userCode))
        throw new ArgumentException("The provided user code is invalid.", nameof (userCode));
      if (!ArgumentValidator.ComputerDescriptionIsValid(computerDescription))
        throw new ArgumentException("The provided service tag or serial number is invalid.", nameof (computerDescription));
      try
      {
        return this.Channel.TransferLicense(licenseId, userCode, computerDescription);
      }
      catch (FaultException<ArgumentFault> ex)
      {
        throw new ArgumentException(ex.Message, ex.Detail.ParameterName);
      }
    }

    private CadwellLicensingServiceClient(Binding binding, EndpointAddress endpointAddress)
      : base(binding, endpointAddress)
    {
    }
  }
}
