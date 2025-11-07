// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.LicensingFunctions
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class LicensingFunctions
  {
    public static string X = "D0n'tCh4ng3me789";
    public static readonly string EventViewerLog = "CLS";
    public static readonly short MaxFeatureCount = 40;

    public static UserCodeInfo DecodeUserCode(string userCode)
    {
      userCode = userCode.ToUpperInvariant();
      userCode = userCode.Replace("-", "");
      if (!string.IsNullOrWhiteSpace(userCode))
      {
        if (userCode.Length == 22)
        {
          try
          {
            return new UserCodeInfo(userCode.Substring(0, 2) + userCode.Substring(3, 3) + userCode.Substring(7, 1) + userCode.Substring(9, 4) + userCode.Substring(14, 2) + userCode.Substring(17, 3) + userCode.Substring(21, 1), userCode.Substring(6, 1) + userCode.Substring(13, 1) + userCode.Substring(20, 1) + userCode.Substring(16, 1) + userCode.Substring(2, 1) + userCode.Substring(8, 1));
          }
          catch (FormatException ex)
          {
            throw new ArgumentException("The provided user code is not valid.", nameof (userCode));
          }
          catch (OverflowException ex)
          {
            throw new ArgumentException("The provided user code is not valid.", nameof (userCode));
          }
        }
      }
      throw new ArgumentException("The provided user code is not valid.", nameof (userCode));
    }

    public static string SplitIntoParts(ushort partLength, char splitCharacter, string s)
    {
      short num = 0;
      StringBuilder stringBuilder = new StringBuilder(s);
      for (ushort index = partLength; (int) index + (int) num < stringBuilder.Length; index += partLength)
      {
        stringBuilder.Insert((int) index + (int) num, splitCharacter);
        ++num;
      }
      return stringBuilder.ToString();
    }

    public static void EncryptConnectionStrings()
    {
      System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(Process.GetCurrentProcess().MainModule.FileName);
      ConnectionStringsSection connectionStrings = configuration.ConnectionStrings;
      if (connectionStrings.SectionInformation.IsProtected)
        return;
      connectionStrings.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
      connectionStrings.SectionInformation.ForceSave = true;
      configuration.Save(ConfigurationSaveMode.Modified);
    }
  }
}
