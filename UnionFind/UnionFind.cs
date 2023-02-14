using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class UnionFind
    {
        private int[] arr;

        public UnionFind(int n)
        {
            this.arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -1;
            }
        }

        public int FindParentIterative(int x) 
        {
            while (arr[x] >= 0)
            {
                x = arr[x];
            }

            return x;
        }

        public int FindParentRecursive(int x)
        {
            if (arr[x] < 0)
            {
                return x;
            }

            return FindParentRecursive(arr[x]);
        }

        public int this[int index]
        {
            get
            {
                return this.arr[index];
            }

            set
            {
                this.arr[index] = value;
            }
        }
    }
}
