// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.ArgumentFault
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System.Runtime.Serialization;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [DataContract]
  public class ArgumentFault
  {
    [DataMember]
    public string ParameterName { get; set; }

    public ArgumentFault(string parameterName) => this.ParameterName = parameterName;
  }
}
