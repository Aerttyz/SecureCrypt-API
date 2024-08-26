


using System.Numerics;

namespace SecureCryptAPI.UseCase
{
    public class GenereteRSA
    {
        public BigInteger Encrypt(BigInteger plaintext, BigInteger e, BigInteger n)
        {
           

            return BigInteger.ModPow(plaintext, e, n);
            
        }
    }
}
