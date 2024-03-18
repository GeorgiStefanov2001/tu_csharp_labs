using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_1
{
    public class Rectangle : Shape, IEliptical
    {
        public double A { get; set; }
        public double B { get; set; }
        
        public Rectangle() { }

        public Rectangle(double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        public bool isEliptic()
        {
            return false;
        }

        public override double GetPerimeter()
        {
            return 2 * (A + B);
        }

        public override double GetSurface()
        {
            return A * B;
        }
    }
}
