using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_1
{
    public class Circle : Shape, IEliptical
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public bool isEliptic()
        {
            return true;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double GetSurface()
        {
            return Math.PI * (Radius * Radius);
        }
    }
}
