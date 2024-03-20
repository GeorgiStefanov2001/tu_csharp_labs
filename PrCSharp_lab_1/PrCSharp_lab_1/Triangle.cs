using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_1
{
    public class Triangle <T>
    {
        public T A { get; set; }
        public T B { get; set; }
        public T C { get; set; }

        public bool GetInstance(out Triangle<T> result)
        {
            MathProvider<T> _math = null;
            result = new Triangle<T>();

            if(typeof(T) == typeof(int))
            {
                _math = new IntMathProvider() as MathProvider<T>;
            }else if(typeof(T) == typeof(double))
            {
                _math = new DoubleMathProvider() as MathProvider<T>;
            }

            if (_math == null)
            {
                return false;
            }

            bool creation_success = false;
            creation_success = ((_math.BiggerThan(_math.Add(A,B), C)) && 
                (_math.BiggerThan(_math.Add(A,C), B) && 
                (_math.BiggerThan(_math.Add(B,C),A))));  

            return creation_success;
        }
    }
}
