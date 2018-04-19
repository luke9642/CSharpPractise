using System;
using App3_5;

namespace App3_6
{
    public interface INumberable<T>
    {
        T GetZero(int tmp);
        T Addition(T left, T right);
        T Multiplication(T left, T right);
    }
    
    public class ComplexNumberable<T> : INumberable<Complex<T>>
    {
        private INumberable<T> _operations;
        
        public ComplexNumberable(INumberable<T> operations)
        {
            _operations = operations;
        }

        public int GetZero(Complex<T> tmp)
        {
            return _operations.GetZero();
        }

        public Complex<T> Addition(Complex<T> left, Complex<T> right)
        {
            
            return new Complex<T>
            {
                Im = _operations.Addition(left.Im, right.Im),
                Re = _operations.Addition(left.Re, right.Re)
            };
        }

        public Complex<T> Multiplication(Complex<T> left, Complex<T> right)
        {
            return new Complex<T>
            {
                Im = _operations.Multiplication(left.Im, right.Im),
                Re = _operations.Multiplication(left.Re, right.Re)
            };
        }
    }

    public class IntNumberable : INumberable<int>
    {
        public int GetZero(int tmp)
        {
            return tmp;
        }
        
        public int Addition(int left, int right)
        {
            return left + right;
        }

        public int Multiplication(int left, int right)
        {
            return left * right;
        }
    }
    
    public class FloatNumberable : INumberable<float>
    {
        public float GetZero(float tmp)
        {
            return tmp;
        }
        
        public float Addition(float left, float right)
        {
            return left + right;
        }

        public float Multiplication(float left, float right)
        {
            return left * right;
        }
    }

    public class DoubleNumberable : INumberable<double>
    {
        public double GetZero(double tmp)
        {
            return tmp;
        }
        
        public double Addition(double left, double right)
        {
            return left + right;
        }

        public double Multiplication(double left, double right)
        {
            return left * right;
        }
    }
}