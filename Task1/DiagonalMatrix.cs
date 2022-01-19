using System;

namespace Task1
{
    public class DiagonalMatrix<T>
    {
        public delegate void ElementChanged(int iIndexer, int jIndexer, T oldValue, T newValue);

        public event ElementChanged ElementChangedHandler; // this one will save subscribed elements



        internal T[] DiagonalNumbers { get; }
        public int Size { get; }

        public DiagonalMatrix(int size, params T[] diagonalNumbers)
        {
            if (size < 0 || size > diagonalNumbers.Length) //might not need check for bigger than lenght
            {
                throw new ArgumentException();
            }
            else
            {
                Size = size;
            }

            this.DiagonalNumbers = diagonalNumbers;
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 ||
                    j < 0 ||
                    i >= Size ||
                    j >= Size)
                {
                    throw new IndexOutOfRangeException();
                } 
                else if (i == j)
                {
                    return DiagonalNumbers[i];
                }
                else
                {
                    return default;
                }
            }
            set
            {
                if (i < 0 ||
                    j < 0 ||
                    i >= Size ||
                    j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (i == j)
                {
                    dynamic oldValue = DiagonalNumbers[i], newValue = value;
                    if (oldValue != newValue)
                    {
                        ElementChangedHandler?.Invoke(i, j, oldValue, newValue);
                    }
                    else
                    {
                        DiagonalNumbers[i] = value;
                    }
                }
            }
        }

       public void Anouncement(int i, int j, T oldValue, T newValue)
        {
            Console.WriteLine($"Element at [{i}, {j}] has been changed from {oldValue} to {newValue}");
        }
    }
}
