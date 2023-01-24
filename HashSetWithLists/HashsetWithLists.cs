using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HashSetWithLists
{
    public class HashsetWithLists<T> : IEnumerable<T>
    {
        private const int RESIZE_FACTOR = 2;
        private const int BUFFER_SIZE = 16;
        private const double RESIZE_PERCENTAGE = 0.7;

        private List<T>[] buffer;
        private List<int> usedIndeces;

        private int count;

        public HashsetWithLists()
        {
            this.buffer = new List<T>[BUFFER_SIZE];
            this.usedIndeces = new List<int>();
            this.count = 0;
        }

        public bool ContainsValue(T value)
        {
            var hash = value.GetHashCode();
            var index = hash % this.buffer.Length;

            return buffer[index] != null && buffer[index].Contains(value);
        }

        public bool Add(T value)
        {
            var hash = value.GetHashCode();
            var index = hash % this.buffer.Length;

            if (this.ContainsValue(value))
            {
                return false;
            }

            if (this.count / buffer.Length > RESIZE_PERCENTAGE)
            {
                this.Resize(buffer.Length * RESIZE_FACTOR);
                index = hash % this.buffer.Length;
            }

            if (buffer[index] == null)
            {
                buffer[index] = new List<T>();
                this.usedIndeces.Add(index);
            }

            buffer[index].Add(value);
            this.count++;

            return true;
        }

        private void Resize(int newSize)
        {
            var newBuffer = new List<T>[newSize];
            var newIndeces = new List<int>();

            foreach (var x in this.usedIndeces)
            {
                foreach (var y in buffer[x])
                {
                    var hash = y.GetHashCode();
                    var index = hash % newSize;

                    if (newBuffer[index] == null)
                    {
                        newBuffer[index] = new List<T>();
                        newIndeces.Add(index);
                    }
                    newBuffer[index].Add(y);
                }
            }

            buffer = newBuffer;
            usedIndeces = newIndeces;
        }

        public bool Remove(T value)
        {
            var hash = value.GetHashCode();
            var index = hash % this.buffer.Length;

            if (buffer[index] == null)
            {
                return false;
            }

            foreach (var x in buffer[index])
            {
                if (x.Equals(value))
                {
                    buffer[index].Remove(value);
                    this.usedIndeces.Remove(index);

                    this.count--;
                    return true;
                }
            }

            return false;
        }

        public T Find(T value)
        {
            var hash = value.GetHashCode();
            var index = hash % this.buffer.Length;

            if (buffer[index] == null)
            {
                throw new ArgumentException("No such value!");
            }

            var ind = buffer[index].IndexOf(value);

            if (ind < 0)
            {
                return default(T);
            }

            return buffer[index][ind];
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var x in this.usedIndeces)
            {
                foreach (var y in buffer[x])
                {
                    yield return y;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
