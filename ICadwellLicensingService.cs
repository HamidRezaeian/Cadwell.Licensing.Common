// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.ICadwellLicensingService
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System.Collections.Generic;
using System.ServiceModel;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [ServiceContract]
  public interface ICadwellLicensingService
  {
    [OperationContract]
    [FaultContract(typeof (ArgumentFault))]
    ActivationInfo ActivateLicense(
      string licenseId,
      string computerId,
      string computerDescription,
      string productId);

    [OperationContract]
    LicenseInfo GetLicense(string licenseId);

    [OperationContract]
    List<LicenseInfo> GetLicenses(
      string productId,
      string customerNumber,
      string machineId,
      short? machineCount,
      string salesOrderNumber,
      bool? isDeactivated,
      bool? isDeleted);

    [OperationContract]
    string GetHardwareLicenseFeatures(string serialNumber, string productId);

    [OperationContract]
    [FaultContract(typeof (ArgumentFault))]
    FeatureUnlockInfo EmergencyUnlockLicense(
      string licenseId,
      string explanation,
      ICollection<short> featureIndexes);

    [OperationContract]
    void UpdateLicensesComputerId(string licenseId, string newComputerId);

    [OperationContract]
    [FaultContract(typeof (ArgumentFault))]
    string ActivateLicenseManually(
      string licenseId,
      string userCode,
      string computerDescription,
      string productId);

    [OperationContract]
    string GenerateUpgradeCode(string licenseId, string userCode);

    [OperationContract]
    [FaultContract(typeof (ArgumentFault))]
    string TransferLicense(string licenseId, string userCode, string computerDescription);
  }
}
