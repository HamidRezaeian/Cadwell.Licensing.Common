// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.FeatureUnlockInfo
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [DataContract]
  public class FeatureUnlockInfo
  {
    [DataMember]
    public string LicenseID { get; private set; }

    [DataMember]
    public string ProductID { get; private set; }

    [DataMember]
    public string FeatureBitString { get; private set; }

    [DataMember]
    public TimeSpan UnlockDuration { get; private set; }

    public FeatureUnlockInfo(string licenseID, string featureBitString, TimeSpan unlockDuration)
    {
      this.LicenseID = licenseID;
      this.FeatureBitString = featureBitString;
      this.UnlockDuration = unlockDuration;
    }
  }
}
