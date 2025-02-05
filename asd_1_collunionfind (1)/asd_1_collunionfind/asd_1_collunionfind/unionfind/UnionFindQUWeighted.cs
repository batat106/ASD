﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_1_collunionfind.unionfind
{
    internal class UnionFindQUWeighted : UnionFindQU
    {
        protected int[] _size; // _size[i] in the number of elements in a subtree rooted at i
        protected int _n;  // total number of elements

        public UnionFindQUWeighted(int n) : base(n)
        {
            // initially each element's index is its own root:
            // _id is the ID of the root (parent) element

            _n = n;
            _size = new int[n];
            for (int i = 0; i < n; i++)
            {
                _size[i] = 1;
            }
        }

        /// <summary>
        /// Make the p-th element to be a child of q-th element's parent
        /// </summary>
        /// <param name="p">p-th element's ID</param>
        /// <param name="q">q-th element's ID</param>
        override protected void _CallUnion(int p, int q)
        {
            // get the root elements of q-th and q-th elements
            int rootP = Root(p);
            int rootQ = Root(q);
            if (rootP == rootQ) return;

            // make smaller root point to larger one:
            // if p is smaller than q
            if (_size[rootP] < _size[rootQ])
            {
                // then parent(p) = q
                _id[rootP] = rootQ;
                _size[rootQ] += _size[rootP];
            }
            // if p is greater than q
            else
            {
                // then parent(q) = p
                _id[rootQ] = rootP;
                _size[rootP] += _size[rootQ];
            }
            // decrease total number of trees/clusters/components
            _n--;
        }
    }
}
