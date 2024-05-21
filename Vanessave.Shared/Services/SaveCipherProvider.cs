using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace Vanessave.Shared.Services;

[UnsupportedOSPlatform("browser")]
public sealed class SaveCipherProvider : IDisposable
{
    public const string Key = "vckiTpRHOzjVf+5/+d9EIw==";
    public const string IV = "zXKcTMyXoZAtt4f0XXsQ2Q==";

    private readonly Aes _aes;

    public SaveCipherProvider()
    {
        _aes = Aes.Create();
        _aes.Key = Convert.FromBase64String(Key);
        _aes.IV = Convert.FromBase64String(IV);
        _aes.Mode = CipherMode.CBC;
    }

    public async Task<string> DecryptSave(Stream save)
    {
        await using var decryptor = GetDecryptStream(save);
        using var textReader = new StreamReader(decryptor);

        return await textReader.ReadToEndAsync();
    }

    public Stream GetDecryptStream(Stream save)
    {
        return new CryptoStream(save, _aes.CreateDecryptor(), CryptoStreamMode.Read);
    }

    public Stream GetEncryptStream(string save)
    {
        var saveStream = new MemoryStream(Encoding.UTF8.GetBytes(save));
        var encryptor = new CryptoStream(saveStream, _aes.CreateEncryptor(), CryptoStreamMode.Read);

        return encryptor;
    }

    public void Dispose()
    {
        _aes.Dispose();
    }
}