// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.LicenseInfo
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System.Runtime.Serialization;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [DataContract]
  public class LicenseInfo
  {
    [DataMember]
    public string LicenseID { get; set; }

    [DataMember]
    public string ProductID { get; set; }

    [DataMember]
    public string CustomerNumber { get; set; }

    [DataMember]
    public string MachineID { get; set; }

    [DataMember]
    public string MachineDescription { get; set; }

    [DataMember]
    public short MachineCount { get; set; }

    [DataMember]
    public string Note { get; set; }

    [DataMember]
    public string SalesOrderNumber { get; set; }

    [DataMember]
    public string PurchasedFeatures { get; set; }

    [DataMember]
    public bool IsDeactivated { get; set; }

    [DataMember]
    public bool IsDeleted { get; set; }

    public LicenseInfo()
    {
    }

    public LicenseInfo(
      string licenseID,
      string productID,
      string customerNumber,
      string machineID,
      string machineDescription,
      short machineCount,
      string note,
      string salesOrderNumber,
      string purchasedFeatures,
      bool isDeactivated,
      bool isDeleted)
    {
      this.LicenseID = licenseID;
      this.ProductID = productID;
      this.CustomerNumber = customerNumber;
      this.MachineID = machineID;
      this.MachineDescription = machineDescription;
      this.MachineCount = machineCount;
      this.Note = note;
      this.SalesOrderNumber = salesOrderNumber;
      this.PurchasedFeatures = purchasedFeatures;
      this.IsDeactivated = isDeactivated;
      this.IsDeleted = isDeleted;
    }
  }
}
