using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> heap;
        private Func<T, T, bool> func;

        public T Top => heap[1];

        public int Count => heap.Count - 1;

        public bool IsEmpty => heap.Count == 1;


        public BinaryHeap(Func<T, T, bool> cmpFunc)
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

        public void RemoveTop()
        {
            var currentIndex = 1;
            int smallerChildIndex = 1;

            this.heap[currentIndex] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);

            var value = this.heap[currentIndex];

            while (currentIndex * 2 + 1 < this.heap.Count)
            {
                smallerChildIndex = this.func(this.heap[currentIndex * 2], this.heap[currentIndex * 2 + 1]) ?
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
