using System;
namespace Task1
{
    public static class Extension
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix,
                                               DiagonalMatrix<T> secondMatrix,
                                               Func<T, T, T> func)
        {
            int newSize = firstMatrix.Size > secondMatrix.Size ? firstMatrix.Size : secondMatrix.Size;

            T[] newElements = new T[newSize];

            for (int i = 0; i < newSize; i++)
            {
                newElements[i] = func(firstMatrix[i, i], secondMatrix[i, i]);
            }

            return new DiagonalMatrix<T>(newSize, newElements);
        }
    }
}
