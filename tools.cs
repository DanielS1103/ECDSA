using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;


namespace ECDsa
{
    internal class Tools
    {
        public class ECPoint{
            public double X; // x coordinate
            public double Y; // y coordinate
        }

        static double a = 0;

        //double point
        public static ECPoint Double(ECPoint A){
            double s = (3 * Math.Pow(A.X, 2) + a) / (2 * A.Y);
            double x = Math.Pow(s, 2) - A.X - A.X;
            double y = s * (A.X - x) - A.Y;
            //se retorna un ECDpoint con las coordenadas x y y
            return new ECPoint { X = x, Y = y };
        } 

        //add two points
        public static ECPoint Add(ECPoint A, ECPoint B){
            double s = (B.Y - A.Y) / (B.X - A.X);
            double x = Math.Pow(s, 2) - A.X - B.X;
            double y = s * (A.X - x) - A.Y;
            //se retorna un ECDpoint con las coordenadas x y y
            return new ECPoint { X = x, Y = y };
        }
    }
}