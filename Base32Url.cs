// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.Base32Url
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public class Base32Url
  {
    private readonly string _alphabet;
    private Dictionary<string, uint> _index;
    private static Dictionary<string, Dictionary<string, uint>> _indexes = new Dictionary<string, Dictionary<string, uint>>(2, (IEqualityComparer<string>) StringComparer.InvariantCulture);
    internal const char StandardPaddingChar = '=';
    internal const string Base32StandardAlphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
    internal const string ZBase32Alphabet = "ybndrfg8ejkmcpqxot1uwisza345h769";
    internal char PaddingChar;
    internal bool UsePadding;
    internal bool IsCaseSensitive;
    internal bool IgnoreWhiteSpaceWhenDecoding;

    private void EnsureAlphabetIndexed()
    {
      if (this._index != null)
        return;
      string key = (this.IsCaseSensitive ? "S" : "I") + this._alphabet;
      Dictionary<string, uint> dictionary;
      if (!Base32Url._indexes.TryGetValue(key, out dictionary))
      {
        lock (Base32Url._indexes)
        {
          if (!Base32Url._indexes.TryGetValue(key, out dictionary))
          {
            dictionary = new Dictionary<string, uint>(this._alphabet.Length, this.IsCaseSensitive ? (IEqualityComparer<string>) StringComparer.InvariantCulture : (IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);
            for (int startIndex = 0; startIndex < this._alphabet.Length; ++startIndex)
              dictionary[this._alphabet.Substring(startIndex, 1)] = (uint) startIndex;
            Base32Url._indexes.Add(key, dictionary);
          }
        }
      }
      this._index = dictionary;
    }

    private string Encode(byte[] data)
    {
      StringBuilder stringBuilder = new StringBuilder(Math.Max((int) Math.Ceiling((double) (data.Length * 8) / 5.0), 1));
      byte[] sourceArray = new byte[8];
      byte[] destinationArray = new byte[8];
      for (int sourceIndex = 0; sourceIndex < data.Length; sourceIndex += 5)
      {
        int length = Math.Min(data.Length - sourceIndex, 5);
        Array.Copy((Array) sourceArray, (Array) destinationArray, sourceArray.Length);
        Array.Copy((Array) data, sourceIndex, (Array) destinationArray, destinationArray.Length - (length + 1), length);
        Array.Reverse((Array) destinationArray);
        ulong uint64 = BitConverter.ToUInt64(destinationArray, 0);
        for (int index = (length + 1) * 8 - 5; index > 3; index -= 5)
          stringBuilder.Append(this._alphabet[(int) ((long) (uint64 >> index) & 31L)]);
      }
      if (this.UsePadding)
        stringBuilder.Append(string.Empty.PadRight(stringBuilder.Length % 8 == 0 ? 0 : 8 - stringBuilder.Length % 8, this.PaddingChar));
      return stringBuilder.ToString();
    }

    private byte[] Decode(string input)
    {
      if (this.IgnoreWhiteSpaceWhenDecoding)
        input = Regex.Replace(input, "\\s+", "");
      if (this.UsePadding)
        input = input.Length % 8 == 0 ? input.TrimEnd(this.PaddingChar) : throw new ArgumentException("Invalid length for a base32 string with padding.");
      this.EnsureAlphabetIndexed();
      MemoryStream memoryStream = new MemoryStream(Math.Max((int) Math.Ceiling((double) (input.Length * 5) / 8.0), 1));
      for (int index1 = 0; index1 < input.Length; index1 += 8)
      {
        int num1 = Math.Min(input.Length - index1, 8);
        ulong num2 = 0;
        int count = (int) Math.Floor((double) num1 * 0.625);
        for (int index2 = 0; index2 < num1; ++index2)
        {
          uint num3;
          if (!this._index.TryGetValue(input.Substring(index1 + index2, 1), out num3))
            throw new ArgumentException("Invalid character '" + input.Substring(index1 + index2, 1) + "' in base32 string, valid characters are: " + this._alphabet);
          num2 |= (ulong) num3 << (count + 1) * 8 - index2 * 5 - 5;
        }
        byte[] bytes = BitConverter.GetBytes(num2);
        Array.Reverse((Array) bytes);
        memoryStream.Write(bytes, bytes.Length - (count + 1), count);
      }
      return memoryStream.ToArray();
    }

    internal Base32Url()
      : this(false, false, false, "ABCDEFGHJKLMNPQRSTUVWXYZ23456789")
    {
    }

    public Base32Url(
      bool padding,
      bool caseSensitive,
      bool ignoreWhiteSpaceWhenDecoding,
      string alternateAlphabet)
    {
      if (alternateAlphabet.Length != 32)
        throw new ArgumentException("Alphabet must be exactly 32 characters long for base 32 encoding.");
      this.PaddingChar = '=';
      this.UsePadding = padding;
      this.IsCaseSensitive = caseSensitive;
      this.IgnoreWhiteSpaceWhenDecoding = ignoreWhiteSpaceWhenDecoding;
      this._alphabet = alternateAlphabet;
    }

    public static byte[] FromBase32String(string input) => new Base32Url().Decode(input);

    public static string ToBase32String(byte[] data) => new Base32Url().Encode(data);

    public static string GetRandomSeed(int length)
    {
      char[] charArray = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();
      byte[] data = new byte[1];
      using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
      {
        cryptoServiceProvider.GetNonZeroBytes(data);
        data = new byte[length];
        cryptoServiceProvider.GetNonZeroBytes(data);
      }
      StringBuilder stringBuilder = new StringBuilder(length);
      foreach (byte num in data)
        stringBuilder.Append(charArray[(int) num % charArray.Length]);
      return stringBuilder.ToString();
    }
  }
}
