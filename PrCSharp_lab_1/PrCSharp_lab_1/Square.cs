using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_1
{
    public class Square : Rectangle { 
        public Square(double a)
        {
            this.A = a;
            this.B = a;
        }    
        public override double GetPerimeter()
        {
            return 4 * A;
        }

        public override double GetSurface()
        {
            return A * A;
        }

        public static double GetSurfaceBySide(double side)
        {
            return side * side;
        }
    }
}
