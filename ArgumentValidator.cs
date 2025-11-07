// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.ArgumentValidator
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class ArgumentValidator
  {
    public static bool ComputerDescriptionIsValid(string computerDescription)
    {
      return !string.IsNullOrWhiteSpace(computerDescription) && computerDescription.Length <= 50;
    }

    public static bool ComputerIdIsValid(string computerId)
    {
      return !string.IsNullOrWhiteSpace(computerId) && computerId.Length == 16;
    }

    public static bool CustomerNumberIsValid(string customerNumber)
    {
      if (string.IsNullOrWhiteSpace(customerNumber))
        return false;
      customerNumber = customerNumber.ToUpper();
      char ch = customerNumber[0];
      if (!ch.Equals('C'))
      {
        ch = customerNumber[0];
        if (!ch.Equals('F'))
        {
          ch = customerNumber[0];
          if (!ch.Equals('T'))
            return false;
        }
      }
      return customerNumber.Length == 7 && int.TryParse(customerNumber.Substring(1, 6), out int _);
    }

    public static bool FeatureBitStringIsValid(string featureBitString)
    {
      switch (featureBitString)
      {
        case null:
          return false;
        case "":
          return false;
        default:
          if (featureBitString.Length > (int) LicensingFunctions.MaxFeatureCount)
            return false;
          foreach (char ch in featureBitString)
          {
            switch (ch)
            {
              case '0':
              case '1':
                continue;
              default:
                return false;
            }
          }
          return true;
      }
    }

    public static bool FeatureBundleDescriptionIsValid(string description)
    {
      return !string.IsNullOrWhiteSpace(description) && description.Length >= 1 && description.Length <= 200;
    }

    public static bool FeatureBundleNameIsValid(string name)
    {
      return !string.IsNullOrWhiteSpace(name) && name.Length >= 1 && name.Length <= 50;
    }

    public static bool FeatureDescriptionIsValid(string description)
    {
      return !string.IsNullOrWhiteSpace(description) && description.Length >= 1 && description.Length <= 200;
    }

    public static bool FeatureIndexIsValid(short featureIndex)
    {
      return featureIndex >= (short) 0 && (int) featureIndex < (int) LicensingFunctions.MaxFeatureCount;
    }

    public static bool FeatureNameIsValid(string name)
    {
      return !string.IsNullOrWhiteSpace(name) && name.Length >= 1 && name.Length <= 50;
    }

    public static bool HoursUnlockedIsValid(short hoursUnlocked)
    {
      return hoursUnlocked >= (short) 0 && hoursUnlocked <= (short) 2160;
    }

    public static bool LicenseIdIsValid(string licenseId)
    {
      return !string.IsNullOrWhiteSpace(licenseId) && licenseId.Length == 8;
    }

    public static bool LicenseNoteIsValid(string licenseNote)
    {
      return string.IsNullOrWhiteSpace(licenseNote) || licenseNote.Length <= 300;
    }

    public static bool MachineCountIsValid(short machineCount)
    {
      return machineCount >= (short) 0 && machineCount <= (short) 99;
    }

    public static bool ProductIdIsValid(string productId)
    {
      return !string.IsNullOrWhiteSpace(productId) && (!(productId != "D0n'tCh4ng3M3") || productId.Length == 1);
    }

    public static bool ProductDescriptionIsValid(string description)
    {
      return !string.IsNullOrWhiteSpace(description) && description.Length >= 1 && description.Length <= 200;
    }

    public static bool ProductNameIsValid(string name)
    {
      return !string.IsNullOrWhiteSpace(name) && name.Length >= 1 && name.Length <= 50;
    }

    public static bool SalesOrderNumberIsValid(string salesOrderNumber)
    {
      return !string.IsNullOrWhiteSpace(salesOrderNumber) && salesOrderNumber.Length <= 10;
    }

    public static bool UnlockExplanationIsValid(string explanation)
    {
      return !string.IsNullOrWhiteSpace(explanation) && explanation.Length <= 200;
    }

    public static bool UserCodeIsValid(string userCode)
    {
      return !string.IsNullOrWhiteSpace(userCode) && userCode.Length == 22;
    }

    public static bool UserIdIsValid(string userId)
    {
      return !string.IsNullOrWhiteSpace(userId) && userId.Length != 0;
    }
  }
}
