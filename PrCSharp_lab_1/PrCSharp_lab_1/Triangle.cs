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
            result = new Triangle<T>();

            bool creation_success = false;
            creation_success = ((A + B > C) && 
                (A + C > B) && 
                (B + C > A)) && 
                ((typeof(T) == typeof(int)) || (typeof(T) == typeof(double)));  

            return creation_success;
        }
    }
}
