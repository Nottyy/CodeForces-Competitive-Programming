using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashset
{
    public class HashsetNew<T> : IEnumerable<T>
    {
        private const int MIN_BUFFER_LENGTH = 16;
        private const int RESIZE_FACTOR = 2;
        private const double FULL_PERCENTAGE = 0.7;

        private SinglyLinkedlist<T>[] buffer;
        private List<uint> usedIndeces;
        public int Count { get; private set; }

        public HashsetNew()
        {
            this.buffer = new SinglyLinkedlist<T>[MIN_BUFFER_LENGTH];
            this.Count = 0;
            this.usedIndeces = new List<uint>();
        }
        public bool Add(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = (uint)(hash % buffer.Length);

            var existed = buffer[index] != null && buffer[index].Contains(value);

            if (existed)
            {
                return false;
            }

            //if ((double)this.Count / buffer.Length > FULL_PERCENTAGE)
            //{
            //    this.Resize(buffer.Length * RESIZE_FACTOR);
            //    index = (uint)(hash % buffer.Length);
            //}

            this.Count++;
            if (buffer[index] == null)
            {
                usedIndeces.Add(index);
            }
            buffer[index] = new SinglyLinkedlist<T>(value, buffer[index]);

            return true;
        }

        public bool Remove(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = (uint)(hash % buffer.Length);
            bool removed;

            if (buffer[index] == null)
            {
                return false;
            }

            buffer[index] = buffer[index].RemoveAndGetNext(value, out removed);
            

            if (removed)
            {
                this.Count--;
                usedIndeces.Remove(index);
                return true;
            }

            return false;
        }

        public bool Contains(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % buffer.Length;

            return buffer[index] != null && buffer[index].Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var y in usedIndeces)
            {
                foreach (var x in buffer[y])
                {
                    yield return x;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize(int newSize)
        {
            var newBuffer = new SinglyLinkedlist<T>[newSize];
            var newIndeces = new List<uint>();

            foreach (var x in this)
            {
                var hash = (uint)x.GetHashCode();
                var index = (uint)(hash % newSize);
                newBuffer[index] = new SinglyLinkedlist<T>(x, newBuffer[index]);
                if (newBuffer[index] == null)
                {
                    newIndeces.Add(index);
                }
            }

            this.buffer = newBuffer;
            this.usedIndeces = newIndeces;
        }
    }
}
