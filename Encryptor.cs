// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.Encryptor
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Text;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class Encryptor
  {
    public static readonly string EventViewerLog = "CLS";

    public static string Encrypt(string text, byte[] key, string initializationVector)
    {
      if (initializationVector != null && initializationVector.Length != 16)
        throw new ArgumentException("The initialization vector provided is invalid.", nameof (initializationVector));
      byte[] initializationVector1 = (byte[]) null;
      if (initializationVector != null)
      {
        try
        {
          initializationVector1 = Encoding.ASCII.GetBytes(initializationVector);
        }
        catch (EncoderFallbackException ex)
        {
          throw new ArgumentException("The provided initialization vector is invalid.", nameof (initializationVector), (Exception) ex);
        }
      }
      return Base32Url.ToBase32String(AESEncryption.EncryptStringToBytes(text, key, initializationVector1));
    }

    public static string Decrypt(string text, byte[] key, string initializationVector = null)
    {
      if (text == null)
        throw new ArgumentNullException(nameof (text));
      if (initializationVector != null && initializationVector.Length != 16)
        throw new ArgumentException("The initialization vector provided is invalid.", nameof (initializationVector));
      byte[] initializationVector1 = (byte[]) null;
      if (initializationVector != null)
      {
        try
        {
          initializationVector1 = Encoding.ASCII.GetBytes(initializationVector);
        }
        catch (EncoderFallbackException ex)
        {
          throw new ArgumentException("The initialization vector provided is invalid.", nameof (initializationVector), (Exception) ex);
        }
      }
      byte[] cipherText;
      try
      {
        cipherText = Base32Url.FromBase32String(text);
      }
      catch (ArgumentException ex)
      {
        throw new ArgumentException("The text provided is invalid.", nameof (text), (Exception) ex);
      }
      return AESEncryption.DecryptStringFromBytes(cipherText, key, initializationVector1);
    }
  }
}
