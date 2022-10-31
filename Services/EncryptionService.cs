using RockLib.Encryption;
using Serilog;
public class EncryptionService
{
    private readonly ICrypto? _crypto;

    public EncryptionService(ICrypto crypto)
    {
        if (crypto != null)
            _crypto = crypto;
    }

    public string Encrypt(string plain)
    {
        if (_crypto == null)
            throw new NullReferenceException();
        Log.Debug($"Encrypting...");
        return _crypto.Encrypt(plain);
    }

    public string Decrypt(string cypher)
    {
        if (_crypto == null)
            throw new NullReferenceException();
        Log.Debug($"Decrypting...");
        return _crypto.Decrypt(cypher);
    }
}