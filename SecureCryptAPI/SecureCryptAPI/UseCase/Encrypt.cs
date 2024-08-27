namespace SecureCryptAPI.UseCase;
using System.Numerics;

public class Encrypt : Utils
{
    public static int EncryptMessage(int message)
    {
        int e = public_key.Value;
        BigInteger encryptedText = BigInteger.ModPow(message, e, n.Value);
        if (encryptedText > int.MaxValue || encryptedText < int.MinValue)
        {
            throw new OverflowException("O resultado da criptografia é muito grande para um int.");
        }

        return (int)encryptedText;
    }

    public List<int> Encoder(string message)
    {
        List<int> encoded = new List<int>();
        foreach (char c in message)
        {
            encoded.Add(EncryptMessage((int)c));
        }
        return encoded;
    }

}
