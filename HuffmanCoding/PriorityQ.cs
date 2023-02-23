using System;
using System.Collections.Generic;

namespace BinaryHeap
{
    public class PriorityQ<T>
    {
        private List<T> heap;
        private Func<T, T, bool> func;

        public T Top => heap[1];

        public int Count => heap.Count - 1;

        public bool IsEmpty => heap.Count == 1;


        public PriorityQ(Func<T, T, bool> cmpFunc)
        {
            this.heap = new List<T>();
            this.heap.Add(default);
            this.func = cmpFunc;
        }
        public void Add(T value)
        {
            heap.Add(value);

            var ind = heap.Count - 1;
            var parentIndex = ind / 2;

            while (ind > 1 && this.func(value, this.heap[parentIndex]))
            {
                var tmp = this.heap[ind];
                this.heap[ind] = this.heap[parentIndex];
                this.heap[parentIndex] = tmp;


                ind = parentIndex;
                parentIndex /= 2;
            }
        }

        public T RemoveTop()
        {
            var currentIndex = 1;
            T value = default;

            if (this.Count == 2)
            {
                var ifFirstIsSmaller = this.func(this.heap[this.Count - 1], this.heap[this.Count]);

                if (!ifFirstIsSmaller)
                {
                    var tmp = this.heap[this.Count - 1];
                    this.heap[this.Count - 1] = this.heap[this.Count];
                    this.heap[this.Count] = tmp;
                }
            }
            var curTop = this.Top;

            value = this.heap[this.heap.Count - 1];

            this.heap[currentIndex] = value;
            this.heap.RemoveAt(this.heap.Count - 1);

            this.HeapifyDown(currentIndex, value);

            return curTop;
        }

        private void HeapifyDown(int currentIndex, T value)
        {
            while (currentIndex * 2 + 1 < this.heap.Count)
            {
                var smallerChildIndex = this.func(this.heap[currentIndex * 2], this.heap[currentIndex * 2 + 1]) ?
                    currentIndex * 2 : currentIndex * 2 + 1;

                if (this.func(this.heap[smallerChildIndex], value))
                {
                    var tmp = this.heap[currentIndex];
                    this.heap[currentIndex] = this.heap[smallerChildIndex];
                    this.heap[smallerChildIndex] = tmp;

                    currentIndex = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
