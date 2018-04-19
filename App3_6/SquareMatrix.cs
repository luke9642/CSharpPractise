namespace App3_6
{
    public class SquareMatrix<T> : Matrix<T> where T : new()
    {
        public SquareMatrix(T[,] array2D, INumberable<T> iNumberable) : base(array2D, iNumberable)
        {
            
        }
        
        bool IsDiagonal()
        {
            for (var i = 0; i < _array2D.GetLength(0); ++i)
            {
                for (var j = 0; j < _array2D.GetLength(1); ++j)
                {
                    if (i == j)
                    {
                        if (_iNumberable.GetZero(_array2D[i, j]))
                            return false;
                    }
                    else
                    {
                        if (!_array2D[i, j].Equals(0))
                            return false;
                    }
                }                
            }
            
            return true;
        }
    }
}