using System;
namespace Task1
{
    public class MatrixTracker<T>
    {
        public DiagonalMatrix<T> MatrixReceived { get; }
        
        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            MatrixReceived = matrix;
            MatrixReceived.ElementChangedHandler += MatrixReceived.Anouncement;
        }

        public void Undo()
        {
            DiagonalMatrix<T>.
        }
    }
}
