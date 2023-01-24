using HashSetWithLists;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class MyDictionary<K, V> : IEnumerable<V>
    {
        private HashsetWithLists<KeyValuePair<K, V>> set;

        public MyDictionary()
        {
            this.set = new HashsetWithLists<KeyValuePair<K, V>>();
        }

        public bool Add(K key, V value)
        {
            return this.set.Add(new KeyValuePair<K, V>(key, value));
        }

        public bool Remove(K key)
        {
            return this.set.Remove(new KeyValuePair<K, V>(key, (V) default));
        }

        public bool Contains(K key)
        {
            return this.set.ContainsValue(new KeyValuePair<K, V>(key, (V)default));
        }

        public KeyValuePair<K, V> Find(K key)
        {
            return this.set.Find(new KeyValuePair<K, V>(key, (V) default));
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key).Value;
            }
            set
            {
                var found = this.Find(key);

                if (found == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    found.Value = value;
                }
            }
        }

        public IEnumerator<V> GetEnumerator()
        {
            foreach (var kvp in this.set)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
