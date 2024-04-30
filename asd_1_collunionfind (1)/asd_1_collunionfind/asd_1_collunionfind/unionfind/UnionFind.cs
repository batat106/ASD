using asd_1_collunionfind.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace asd_1_collunionfind.unionfind
{
    internal class UnionFind : IUnionFind
    {
        protected int[] _id; // ID of a cluster that contains the connected elements

        /**
         * Create a UnionFind data structure
         * @param n Total number of elements in collection
         */
        public UnionFind(int n)
        {
            // init an array of indices
            _id = new int[n];

            // fill-up the array:
            // at first, each element's id equal its actual index,
            // so all elements form an individual own cluster
            for (int i = 0; i < n; i++)
            {
                _id[i] = i;
            }
        }

        // make the p-th element to belong to the cluster of the q-th element
        // union(4, 3) = connect 4 to the cluster of 3
        // NB: If a method in the base class is marked as "virtual",
        // it means that the method can be "overridden" in a derived class!
        virtual public void Union(int p, int q)
        {
            Logger.WriteLine($"union({p}, {q}):");
            Logger.Write("before:\t");
            Print();

            _CallUnion(p, q);

            Logger.Write("after:\t");
            Print();
            Logger.WriteLine();
        }

        // NB: If a method in the base class is marked as "virtual",
        // it means that the method can be "overridden" in a derived class!
        virtual public bool Connected(int p, int q)
        {
            bool result = _CallConnected(p, q);
            Logger.WriteLine($"connected({p}, {q}) = {result}");
            // they belong to the same cluster
            return result;
        }

        /// <summary>
        /// The "core" of the "Union" method
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        virtual protected void _CallUnion(int p, int q)
        {
            int pCluster = _id[p]; // original p-th id = 4
            int qCluster = _id[q]; // original q-th id = 3
            // chain-style change of ids:
            // recursively connect the elements
            for (int i = 0; i < _id.Length; i++)
            {
                // if i-th element belongs to p-th cluster
                if (_id[i] == pCluster) // if id[i] == 4
                {
                    // connect it to the q-th cluster
                    _id[i] = qCluster; // id[i] = 3
                }
            }
        }

        /// <summary>
        /// The "core" of the "Connected" method
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        virtual protected bool _CallConnected(int p, int q)
        {
            return _id[p] == _id[q];
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (int id in _id)
            {
                str.Append(id).Append(" ");
            }
            return str.ToString();
        }

        public void Print()
        {
            Logger.WriteLine(this.ToString());
        }
    }
}
