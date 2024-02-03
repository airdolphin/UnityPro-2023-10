using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AESEncryptionService
{
    private const string _KEY = "aaaa1111bbbb2222";

    public static string Encrypt(string plainText)
    {
        byte[] array;

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_KEY);
            aes.IV = new byte[16];

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(plainText);
            }

            array = memoryStream.ToArray();
        }

        return Convert.ToBase64String(array);
    }

    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrWhiteSpace(cipherText))
        {
            throw new ArgumentException("Encoded text is not valid", nameof(cipherText));
        }

        byte[] buffer;
        try
        {
            buffer = Convert.FromBase64String(cipherText);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Not valid encoded text. Need base64 string.", nameof(cipherText));
        }

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_KEY);
        aes.IV = new byte[16];

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(buffer);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        try
        {
            return streamReader.ReadToEnd();
        }
        catch (CryptographicException)
        {
            throw new CryptographicException("Decoding failed. Encoded text may be not valid");
        }
    }
}