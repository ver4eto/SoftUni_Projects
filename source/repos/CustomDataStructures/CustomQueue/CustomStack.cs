using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack

{
    public class CustomStack
    {
        private const int InitialCapacity = 4;

        private int[] items;

        public CustomStack()
        {
            items = new int[InitialCapacity];
        }
        public int Count { get; private set; }
        public void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public void Push(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }

        public int Pop()
        {
            if (this.items.Length==0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            int lastIndex=Count-1;
            int removedItems = items[lastIndex];

            items[Count - 1] = default;

            //TODO: Shrink if needed

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            Count--;
            return removedItems;
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

        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }

            int lastIndex = Count - 1;
            int lastItem = items[lastIndex];

            return lastItem;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                int currentItem = items[i];
                action(currentItem);
            }
            //Тъй като е ЛИФО структура не е ли по-логично да се обхожда така?
            //for (int i = Count - 1; i >= 0; i--)
            //{
            //    int currentItem = items[i];
            //    action(currentItem);
            //}
        }


    }
    
    
}

