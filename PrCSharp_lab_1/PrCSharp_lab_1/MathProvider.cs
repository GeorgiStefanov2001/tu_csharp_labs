using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_1
{
    abstract class MathProvider<T>
    {
        public abstract T Divide(T a, T b);
        public abstract T Multiply(T a, T b);
        public abstract T Add(T a, T b);
        public abstract T Negate(T a);

        public abstract bool BiggerThan(T a, T b);
        public virtual T Subtract(T a, T b)
        {
            return Add(a, Negate(b));
        }
    }

    class DoubleMathProvider : MathProvider<double>
    {
        public override double Divide(double a, double b)
        {
            return a / b;
        }

        public override double Multiply(double a, double b)
        {
            return a * b;
        }

        public override double Add(double a, double b)
        {
            return a + b;
        }

        public override bool BiggerThan(double a, double b)
        {
            return a > b;
        }

        public override double Negate(double a)
        {
            return -a;
        }
    }

    class IntMathProvider : MathProvider<int>
    {
        public override int Divide(int a, int b)
        {
            return a / b;
        }

        public override int Multiply(int a, int b)
        {
            return a * b;
        }

        public override int Add(int a, int b)
        {
            return a + b;
        }

        public override bool BiggerThan(int a, int b)
        {
            return a > b;
        }

        public override int Negate(int a)
        {
            return -a;
        }
    }
}
