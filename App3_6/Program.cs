using System;
using System.Collections.Generic;

namespace App3_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var array2D = new float[5, 5];
            var matrix = new Matrix<float>(array2D, new FloatNumberable());
            
            for (var i = 0; i < 5; ++i)
                for (var j = 0; j < 5; ++j)
                    matrix.SetElement(i, j, (i+j) % 5);

            var newMatrix = matrix.Add(matrix);
            
            for (var i = 0; i < 5; ++i)
            {
                for (var j = 0; j < 5; ++j)
                {
                    Console.Write(newMatrix.GetElement(i, j));
                }
                
                Console.WriteLine();
            }
        }
    }
}