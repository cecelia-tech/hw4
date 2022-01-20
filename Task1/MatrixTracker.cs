﻿using System;
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
            if (MatrixReceived.undoArgs != null)
            {
                MatrixReceived[MatrixReceived.undoArgs.I, MatrixReceived.undoArgs.J] =
                    MatrixReceived.undoArgs.OldValue;
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }
    }
}
