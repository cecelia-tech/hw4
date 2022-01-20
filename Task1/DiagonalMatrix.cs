using System;

namespace Task1
{
    public class UndoArgs : EventArgs
    {
        public int I { get; set; }
        public int J { get; set; }
        public dynamic OldValue { get; set; }
        public dynamic NewValue { get; set; }
    }

    public class DiagonalMatrix<T>
    {
        //public delegate void ElementChanged(int iIndexer, int jIndexer, T oldValue, T newValue);

        public event EventHandler<UndoArgs> ElementChangedHandler; // this one will save subscribed elements

        public UndoArgs undoArgs;

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
                        UndoArgs undoArgs1 = new UndoArgs();

                        undoArgs1.I = i;
                        undoArgs1.J = j;
                        undoArgs1.OldValue = oldValue;
                        undoArgs1.NewValue = newValue;

                        undoArgs = undoArgs1;

                        ElementChangedHandler?.Invoke(this,undoArgs);
                    }
                    else
                    {
                        DiagonalNumbers[i] = value;
                    }
                }
            }
        }

       public void Anouncement(object sender, UndoArgs e)
        {
            Console.WriteLine($"Element at [{e.I}, {e.J}] has been changed from {e.OldValue} to {e.NewValue}");
        }
    }
}
