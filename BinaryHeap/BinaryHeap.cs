using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
