using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashset
{
    public class SinglyLinkedlist<T> : IEnumerable<T>
    {
        private T value;
        private SinglyLinkedlist<T> next;

        public SinglyLinkedlist(T value, SinglyLinkedlist<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public bool Contains(T value)
        {
            var node = this;

            if (node.value.Equals(value))
            {
                return true;
            }
            if (node.next == null)
            {
                return false;
            }

            return node.next.Contains(value);
        }

        public SinglyLinkedlist<T> RemoveAndGetNext(T value, out bool removed)
        {
            if (this.value.Equals(value))
            {
                removed = true;
                return this.next;
            }

            if (this.next == null)
            {
                removed = false;
                return this;
            }

            this.next = this.next.RemoveAndGetNext(value, out removed);
            return this;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var node = this;
            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
