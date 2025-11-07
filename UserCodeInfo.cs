// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.UserCodeInfo
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

#nullable disable
namespace Cadwell.Licensing.Common
{
  public class UserCodeInfo
  {
    public string ComputerID { get; private set; }

    public string RandomString { get; private set; }

    public UserCodeInfo(string computerID, string randomString)
    {
      this.ComputerID = computerID;
      this.RandomString = randomString;
    }
  }
}
