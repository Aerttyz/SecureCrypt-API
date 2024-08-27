namespace SecureCryptAPI.UseCase;
using System.Numerics;
using System.Linq;
public class Encrypt : Utils
{
    public static int EncryptMessage(int message)
    {
        int e = public_key.Value;
        BigInteger encryptedText = BigInteger.ModPow(message, e, n.Value);
        if (encryptedText > int.MaxValue || encryptedText < int.MinValue)
        {
            throw new OverflowException("error");
        }

        return (int)encryptedText;
    }

    public List<string> Encoder(string message)
    {
        List<int> encoded = new List<int>();
        foreach (char c in message)
        {
            encoded.Add(EncryptMessage((int)c));
        }
        maxLength = encoded.Max().ToString().Length;
        List<string> formattedEncoded = new List<string>();
        foreach(int number in encoded)
        {
            formattedEncoded.Add(number.ToString().PadLeft(maxLength, '0'));
        }
        return formattedEncoded;
    }
    public string EncoderToString(string message)
    {
        List<string> encoded = Encoder(message);
        return string.Join("", encoded);
    }

}
