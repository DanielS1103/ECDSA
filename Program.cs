using ECDsa;
using System.Numerics;

BigInteger k = BigInteger.Parse("1", System.Globalization.NumberStyles.HexNumber);
Tools.ECPoint PublicKey = Tools.Multiply(k);

Console.WriteLine("Public Key: ");
Console.WriteLine("X: " + PublicKey.X.ToString("x2").TrimStart(new char[] { '0' }));
Console.WriteLine("Y: " + PublicKey.Y.ToString("x2").TrimStart(new char[] { '0' }));