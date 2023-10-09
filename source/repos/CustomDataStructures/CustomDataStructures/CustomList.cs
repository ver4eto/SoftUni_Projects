using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;


        public int Count { get; private set; }
        public CustomList()
        {
                this.items = new int[InitialCapacity];
        }

        public int this[int index]
        {
            get
            {
                ThrowNewExceptionIfIndexOutOfRange(index);
                return items[index];
            }

            set 
            {
                ThrowNewExceptionIfIndexOutOfRange(index);
                items[index] = value;
            }
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ThrowNewExceptionIfIndexOutOfRange(firstIndex);
            ThrowNewExceptionIfIndexOutOfRange(secondIndex);

            int temp =items[ firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
       
        private void ThrowNewExceptionIfIndexOutOfRange(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int  RemoveAt(int index)
        {
            ThrowNewExceptionIfIndexOutOfRange(index);
            int removedItem = items[index];

            ShiftLeft(index);
            Count--;

            if (Count <= items.Length/4)
            {
                Shrink();
            }

            return removedItem;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];

            }

            items = copy;
        }

        public void Add(int item)
        {
            if (items.Length==Count)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }

        public void AddRange (int[] items)
        {
            foreach (int item in items)
            {
                Add(item);
            }
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i]; 
            }

            items = copy;
        }

        public void InsertAt(int index, int element)
        {
            ThrowNewExceptionIfIndexOutOfRange(index);
            if (items.Length == Count)
            {
                Resize();
            }

            ShiftRight(index);
            items[index] = element;
            Count++;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
        }
    }
}
