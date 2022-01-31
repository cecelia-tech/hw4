using System;
namespace Task1
{
    public class MatrixTracker<T>
    {
        public DiagonalMatrix<T> MatrixReceived { get; }
        
        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            MatrixReceived = diagonalMatrix;
            //here we subscribe to the event
            MatrixReceived.ElementChangedHandler += MatrixReceived.Anouncement;
        }

        public void Undo()
        {
            if (MatrixReceived.undoArgs != null)
            {
                MatrixReceived[MatrixReceived.undoArgs.I, MatrixReceived.undoArgs.I] =
                    MatrixReceived.undoArgs.OldValue;
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }
    }
}
