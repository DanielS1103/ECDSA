using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Globalization;


namespace ECDsa
{
    internal class Tools
    {
        public class ECPoint{
            public BigInteger X; // x coordinate
            public BigInteger Y; // y coordinate
        }

        // Recommended Parameters secp256k1
        public static readonly BigInteger p = BigInteger.Parse("0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFC2F", NumberStyles.HexNumber);
        public static readonly BigInteger N = BigInteger.Parse("0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEBAAEDCE6AF48A03BBFD25E8CD0364141", NumberStyles.HexNumber);

        private static readonly BigInteger a = 0;
        private static readonly BigInteger b = 7;

        // Generator Point
        public static readonly ECPoint G = new()
        {
            X = BigInteger.Parse("79BE667EF9DCBBAC55A06295CE870B07029BFCDB2DCE28D959F2815B16F81798", NumberStyles.HexNumber),
            Y = BigInteger.Parse("485D3EDD3A883D2C66F38CBB8A5E9AFD4C77629A099113C662A4D18E73AFA9B", NumberStyles.HexNumber)
        };
        }

        //extended euclidean algorithm
        public static BigInteger ComputationalInverseValue(BigInteger a, BigInteger mod){
            BigInteger i, j, y, y1, y2, quotient, remainder;
            i = mod;
            j = a;
            y2 = 0;
            y1 = 1;
            do{
                quotient = i / j;
                remainder = i - (j * quotient);
                y = y2 - (y1 * quotient);
                i = j;
                j = remainder;
                y2 = y1;
                y1 = y;
            } while (j > 0);

            if (i != 1){
                return -1;
            }
            return y2%mod;
        }
        
        //multiplicative inverse
        private static BigInteger InverseModP(BigInteger a) => ComputationalInverseValue(a, P);
        private static BigInteger InverseModN(BigInteger a) => ComputationalInverseValue(a, N);
        //double point
        private static ECPoint Double(ECPoint A){
            BigInteger s = (3 * BigInteger.Pow(A.X, 2) + a) * InverseModP(2 * A.Y) % P;
            BigInteger x = (BigInteger.Pow(s, 2) + P - A.X + P - A.X) % P;
            BigInteger y = (s * (P + A.X - x) + P - A.Y) % P;
            //se retorna un ECDpoint con las coordenadas x y y
            return new ECPoint { X = x, Y = y };
        } 

        //add two points
        public static ECPoint Add(ECPoint A, ECPoint B){
            if(A.X == B.Y) return Double(A);
            BigInteger s = (B.Y + P - A.Y) * InverseModP(B.X + P - A.X) % P;
            BigInteger x = (BigInteger.Pow(s, 2) + P - A.X + P - B.X) % P;
            BigInteger y = (s * (p + A.X - x) + P - A.Y) % P;
            //se retorna un ECDpoint con las coordenadas x y y
            return new ECPoint { X = x, Y = y };
        }

        //multiply a point by a scalar
        public static ECPoint Multiply(BigInteger k, ECPoint? point = null){
            point ??= G;
            ECPoint current = point;
            string binary = ToBinaryString(k);
            for (int i = 1; i < binary.Length; i++){
                current = Double(current);
                if (binary[i] == '1'){
                    current = Add(current, point);
                }
            }
            return current;
        }
        //To binary string
        private static string ToBinaryString(BigInteger bigint){
            byte[] bytes = bigint.ToByteArray();
            int idx = bytes.Length - 1;

            StringBuilder base2 = new();
            string binary = Convert.ToString(bytes[idx], 2);

            if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append(binary);
            }
            for(idx--; idx >= 0; idx--){
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }
            return base2.ToString();
        }
    }
}