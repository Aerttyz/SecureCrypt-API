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
                throw new OverflowException("Error");
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
        public string DecoderFromString(string message)
        {
            List<string> chucks = new List<string>();
            for(int i=0; i<=message.Length; i+= maxLength)
            {
                if(i + maxLength <= message.Length)
                {
                    chucks.Add(message.Substring(i, maxLength));
                }
            }
            List<int> decodedNumber = chucks.Select(chuck => int.Parse(chuck)).ToList();
            return Decoder(decodedNumber);
            
        }
    }
}
