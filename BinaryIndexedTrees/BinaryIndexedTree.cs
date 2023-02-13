using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinaryIndexedTrees
{
    public class BinaryIndexedTree<T>
    {
        public T[] tree;

        public int realN;

        private Func<T, T, T> cmpFunc;

        public BinaryIndexedTree(int n, Func<T, T, T> cmpFunc)
        {
            this.realN = 1;

            while (this.realN < n)
            {
                this.realN *= 2;
            }
            this.tree = new T[this.realN * 2];
            this.cmpFunc = cmpFunc;
        }

        public BinaryIndexedTree(ICollection<T> initial, Func<T, T, T> cmpFunc)
            : this(initial.Count, cmpFunc)
        {
            int index = this.realN;
            foreach (var x in initial)
            {
                this.tree[index] = x;
                index++;
            }
            var w = 5;

            for (int i = this.realN; i < this.realN + initial.Count; i++)
            {
                index = i;
                while (index > 1)
                {
                    this.Update(index);

                    index /= 2;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return this.tree[this.realN + index];
            }
            set
            {
                var indexCur = this.realN + index;
                this.tree[indexCur] = value;

                while (indexCur > 1)
                {
                    this.Update(indexCur);

                    indexCur /= 2;
                }
            }
        }

        public T GetInterval(int leftQuery, int rightQuery)
        {
            return this.GetInterval(leftQuery, rightQuery, 1, 0, this.realN);
        }

        private T GetInterval(int leftQuery, int rightQuery, int index, int leftNode, int rightNode)
        {
            if (leftQuery == leftNode && rightQuery == rightNode)
            {
                return this.tree[index];
            }

            int middleNode = (leftNode + rightNode) / 2;

            if (rightQuery <= middleNode)
            {
                return this.GetInterval(leftQuery, rightQuery, index * 2, leftNode, middleNode);
            }

            if (leftQuery >= middleNode)
            {
                return this.GetInterval(leftQuery, rightQuery, index * 2 + 1, middleNode, rightNode);
            }

            return this.cmpFunc(
                this.GetInterval(leftQuery, middleNode, index * 2, leftNode, middleNode),
                this.GetInterval(middleNode, rightQuery, index * 2 + 1, middleNode, rightNode));
        }

        private void Update(int index)
        {
            this.tree[index / 2] = cmpFunc(this.tree[index], this.tree[index ^ 1]);
        }
    }
}
