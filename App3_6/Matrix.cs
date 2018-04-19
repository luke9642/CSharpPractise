using System.Collections.Generic;

namespace App3_6
{
    public class Matrix<T> where T : new()
    {
        protected INumberable<T> _iNumberable;
        protected T[,] _array2D;

        public Matrix(T[,] array2D, INumberable<T> iNumberable)
        {
            _array2D = array2D;
            _iNumberable = iNumberable;
        }
        
        public void SetElement(int x, int y, T element)
        {
            _array2D[x, y] = element;
        }
        
        public T GetElement(int x, int y)
        {
            return _array2D[x, y];
        }

        public Matrix<T> Add(Matrix<T> matrix)
        {
            var newMatrix = new Matrix<T>(new T[_array2D.GetLength(0), _array2D.GetLength(1)], _iNumberable);
            
            for (var i = 0; i < _array2D.GetLength(0); ++i)
                for (var j = 0; j < _array2D.GetLength(1); ++j)
                    newMatrix.SetElement(i, j, _iNumberable.Addition(_array2D[i, j], matrix._array2D[i, j]));
            
            return newMatrix;
        }
        
        public Matrix<T> Multiplicate(Matrix<T> matrix)
        {
            var newMatrix = new Matrix<T>(new T[_array2D.GetLength(0), _array2D.GetLength(1)], _iNumberable);

            for (var i = 0; i < _array2D.GetLength(0); ++i)
                for (var j = 0; j < matrix._array2D.GetLength(1); ++j)
                    for (var k = 0; k < _array2D.GetLength(1); ++k)
                        newMatrix.SetElement(i, j, _iNumberable.Addition(newMatrix.GetElement(i, j), _iNumberable.Multiplication(_array2D[i, k], matrix._array2D[k, j])));

            return newMatrix;
        }
    }
}