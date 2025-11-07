// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.ActivationInfo
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System.Runtime.Serialization;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [DataContract]
  public class ActivationInfo
  {
    [DataMember]
    public string Features { get; private set; }

    [DataMember]
    public string ProductID { get; private set; }

    [DataMember]
    public short ComputerCount { get; private set; }

    public ActivationInfo(string features, string productID, short computerCount)
    {
      this.Features = features;
      this.ProductID = productID;
      this.ComputerCount = computerCount;
    }
  }
}
