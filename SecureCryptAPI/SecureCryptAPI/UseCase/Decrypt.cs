using System.Numerics;

namespace SecureCryptAPI.UseCase
{
    public class Decrypt : Utils
    {
        public int DecryptMessage(int message)
        {
            int d = private_key.Value;
            BigInteger encryptedText = BigInteger.ModPow(message, d, n.Value);
            if (encryptedText > int.MaxValue || encryptedText < int.MinValue)
            {
                throw new OverflowException("O resultado da criptografia é muito grande para um int.");
            }

            return (int)encryptedText;
        }
        public string Decoder(List<int> message)
        {
            string decoded = "";
            foreach (int c in message)
            {
                decoded += (char)DecryptMessage(c);
            }
            return decoded;
        }
    }
}
