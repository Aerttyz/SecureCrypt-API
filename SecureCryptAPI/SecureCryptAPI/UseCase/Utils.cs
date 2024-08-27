


using System.Numerics;
using SecureCryptAPI.Models;

namespace SecureCryptAPI.UseCase
{
    public class Utils : RSA
    {
        protected static HashSet<int> prime = new HashSet<int>();

        protected static int? public_key = null;

        protected static int? private_key = null;

        protected static int? n = null;

        protected static Random random = new Random();

        public static int EncontrarEnesimoPrimo(int n)
        {
            if (n < 1)
                throw new ArgumentException("O valor de n deve ser maior que 0.");

            int contador = 0;
            int numero = 2;

            while (true)
            {
                if (EhPrimo(numero))
                {
                    contador++;
                    if (contador == n)
                    {
                        return numero;
                    }
                }
                numero++;
            }
        }

        public static bool EhPrimo(int numero)
        {
            if (numero < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                    return false;
            }

            return true;
        }
        public void GenerateKeys()
        {
            int num1, num2;
            do
            {
                num1 = random.Next(255, 350);
                num2 = random.Next(255, 350);
            } while (num1 == num2);
            int p = EncontrarEnesimoPrimo(num1);
            int q = EncontrarEnesimoPrimo(num2);
            n = p * q;
            int phi = (p - 1) * (q - 1);
            int e = 2;
            while (e < phi)
            {
                if (GreatestCommonDivisor(e, phi) == 1)
                {
                    break;
                }
                e++;
            }
            public_key = e;
            int d = 2;
            while (true)
            {
                if((d * e) % phi == 1)
                {
                    break;
                }
                d++;
            }
            private_key = d;
        }
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GreatestCommonDivisor(b, a % b);
        }
      


    }
}
