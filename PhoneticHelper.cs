// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.PhoneticHelper
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class PhoneticHelper
  {
    public static Dictionary<char, string> PhoneticAlphabet = new Dictionary<char, string>()
    {
      {
        'A',
        "Alpha"
      },
      {
        'B',
        "Bravo"
      },
      {
        'C',
        "Charlie"
      },
      {
        'D',
        "Delta"
      },
      {
        'E',
        "Echo"
      },
      {
        'F',
        "Foxtrot"
      },
      {
        'G',
        "Golf"
      },
      {
        'H',
        "Hotel"
      },
      {
        'I',
        "India"
      },
      {
        'J',
        "Juliet"
      },
      {
        'K',
        "Kilo"
      },
      {
        'L',
        "Lima"
      },
      {
        'M',
        "Mike"
      },
      {
        'N',
        "November"
      },
      {
        'O',
        "Oscar"
      },
      {
        'P',
        "Papa"
      },
      {
        'Q',
        "Quebec"
      },
      {
        'R',
        "Romeo"
      },
      {
        'S',
        "Sierra"
      },
      {
        'T',
        "Tango"
      },
      {
        'U',
        "Uniform"
      },
      {
        'V',
        "Victor"
      },
      {
        'W',
        "Whiskey"
      },
      {
        'X',
        "X-Ray"
      },
      {
        'Y',
        "Yankee"
      },
      {
        'Z',
        "Zulu"
      }
    };

    public static string GetPhoneticString(string input)
    {
      input = !string.IsNullOrWhiteSpace(input) ? input.Replace("-", "").Replace(" ", "") : throw new ArgumentException(nameof (input));
      StringBuilder stringBuilder = new StringBuilder();
      int num = 1;
      foreach (char key in input)
      {
        if (PhoneticHelper.PhoneticAlphabet.ContainsKey(key))
          stringBuilder.Append(PhoneticHelper.PhoneticAlphabet[key] + ", ");
        else
          stringBuilder.Append(key.ToString() + ", ");
        if (num % 4 == 0)
          stringBuilder.Append(Environment.NewLine);
        ++num;
      }
      return stringBuilder.ToString().TrimEnd('\r', '\n', ' ', ',');
    }
  }
}
