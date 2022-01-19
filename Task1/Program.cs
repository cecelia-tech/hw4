using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 6, 7, 8, 9, 10};

            DiagonalMatrix<int> intMatrix1 = new DiagonalMatrix<int>(5, array1);
            DiagonalMatrix<int> intMatrix2 = new DiagonalMatrix<int>(5, array2);

            DiagonalMatrix<int> addedMatrix = intMatrix1.Add(intMatrix2, Extension.AddElements);

            //intMatrix1.ElementChangedHandler += intMatrix1.Anouncement;

            MatrixTracker<int> matrixTracker = new MatrixTracker<int>(intMatrix1);

            intMatrix1[0, 0] = 11;
            intMatrix1[1, 1] = 22;
            intMatrix1[2, 2] = 33;
        }
    }
}
