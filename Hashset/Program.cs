using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Hashset
{
    public class Cat
    {
        private string color;
        private int dailyFeedings;

        public Cat(string color, int dailyFeedings)
        {
            this.color = color;
            this.dailyFeedings = dailyFeedings;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Cat;
            return this.color == other.color && this.dailyFeedings == other.dailyFeedings;
        }

        public override int GetHashCode()
        {
            return this.color.GetHashCode() ^ this.dailyFeedings.GetHashCode();
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            var cat1 = new Cat("red", 4);
            var cat2 = new Cat("red", 4);
            var cat3 = new Cat("grey", 1);

            Console.WriteLine(cat1.GetHashCode());
            Console.WriteLine(cat2.GetHashCode());

        }
    }

    public class HashsetNew<T>
    {
        private T[] buffer;

        public HashsetNew()
        {
            this.buffer = new T[100];
        }
        public void Add(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % buffer.Length;
            this.buffer[index] = value;
        }

        public void Remove(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % buffer.Length;
            this.buffer[index] = (T)default;
        }

        public bool Contains(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = hash % buffer.Length;
            return this.buffer[index] != null ? true : false;
        }
    }
}
