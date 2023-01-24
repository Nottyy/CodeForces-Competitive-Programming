using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class KeyValuePair<K, V>
    {
        private readonly K key;
        private V value;

        public K Key => key;
        public V Value { get { return this.value; } set { this.value = value; } }

        public KeyValuePair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            var other = obj as KeyValuePair<K, V>;

            return this.key.Equals(other.key);
        }

        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }
    }
}
