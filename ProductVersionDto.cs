// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.ProductVersionDto
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [DataContract]
  public class ProductVersionDto
  {
    [DataMember]
    public int ID { get; set; }

    [DataMember]
    public char ProductID { get; set; }

    [DataMember]
    public Version Version { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public string ReleaseNotes { get; set; }

    [DataMember]
    public string Installer { get; set; }

    [DataMember]
    public DateTime AvailabilityDate { get; set; }

    [DataMember]
    public bool IsDeleted { get; set; }

    public ProductVersionDto(
      int id,
      char productId,
      Version version,
      string description,
      string releaseNotes,
      string installer,
      DateTime availabilityDate,
      bool isDeleted)
    {
      this.ID = id;
      this.ProductID = productId;
      this.Version = version;
      this.Description = description;
      this.ReleaseNotes = releaseNotes;
      this.Installer = installer;
      this.AvailabilityDate = availabilityDate;
      this.IsDeleted = isDeleted;
    }
  }
}
