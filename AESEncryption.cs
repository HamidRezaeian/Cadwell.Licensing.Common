// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.AESEncryption
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.IO;
using System.Security.Cryptography;

#nullable disable
namespace Cadwell.Licensing.Common
{
  internal static class AESEncryption
  {
    public static byte[] EncryptStringToBytes(
      string plainText,
      byte[] key,
      byte[] initializationVector)
    {
      if (plainText == null || plainText.Length <= 0)
        throw new ArgumentNullException(nameof (plainText));
      if (key == null || key.Length == 0)
        throw new ArgumentNullException(nameof (key));
      if (initializationVector != null)
      {
        if (initializationVector.Length != 0)
        {
          try
          {
            using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
            {
              cryptoServiceProvider.Key = key;
              cryptoServiceProvider.IV = initializationVector;
              ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor(cryptoServiceProvider.Key, cryptoServiceProvider.IV);
              using (MemoryStream memoryStream = new MemoryStream())
              {
                using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
                {
                  using (StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream))
                    streamWriter.Write(plainText);
                  return memoryStream.ToArray();
                }
              }
            }
          }
          catch (Exception ex)
          {
            throw new ApplicationException("The encryption failed.", ex);
          }
        }
      }
      throw new ArgumentNullException(nameof (initializationVector));
    }

    public static string DecryptStringFromBytes(
      byte[] cipherText,
      byte[] key,
      byte[] initializationVector)
    {
      if (cipherText == null || cipherText.Length == 0)
        throw new ArgumentNullException(nameof (cipherText));
      if (key == null || key.Length == 0)
        throw new ArgumentNullException(nameof (key));
      if (initializationVector != null)
      {
        if (initializationVector.Length != 0)
        {
          try
          {
            using (AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider())
            {
              cryptoServiceProvider.Key = key;
              cryptoServiceProvider.IV = initializationVector;
              ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor(cryptoServiceProvider.Key, cryptoServiceProvider.IV);
              using (MemoryStream memoryStream = new MemoryStream(cipherText))
              {
                using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
                {
                  using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
                    return streamReader.ReadToEnd();
                }
              }
            }
          }
          catch (Exception ex)
          {
            throw new ApplicationException("The decryption failed.", ex);
          }
        }
      }
      throw new ArgumentNullException(nameof (initializationVector));
    }
  }
}
