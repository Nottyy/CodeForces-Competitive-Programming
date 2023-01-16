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
        public int Count { get; private set; }

        public HashsetNew()
        {
            this.buffer = new SinglyLinkedlist<T>[MIN_BUFFER_LENGTH];
            this.Count = 0;
        }
        public bool Add(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % buffer.Length;

            var existed = buffer[index] != null && buffer[index].Contains(value);

            if (existed)
            {
                return false;
            }

            if ((double)this.Count / buffer.Length > FULL_PERCENTAGE)
            {
                this.Resize(buffer.Length * RESIZE_FACTOR);
                index = hash % buffer.Length;
            }

            this.Count++;
            buffer[index] = new SinglyLinkedlist<T>(value, buffer[index]);

            return true;
        }

        public bool Remove(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % buffer.Length;

            if (buffer[index] == null)
            {
                return false;
            }

            bool removed;

            buffer[index].Remove(value, out removed);
            if (removed)
            {
                this.Count--;
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
            foreach (var list in buffer)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (var x in list)
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

            foreach (var x in this)
            {
                var hash = (uint)x.GetHashCode();
                var index = hash % newSize;
                newBuffer[index] = new SinglyLinkedlist<T>(x, newBuffer[index]);
            }

            buffer = newBuffer;
        }
    }
}
