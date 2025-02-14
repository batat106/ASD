﻿using asd_1_collunionfind.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_1_collunionfind.unionfind
{
    internal class UnionFindQU : UnionFind
    {
        public UnionFindQU(int n) : base(n)
        {
            // initially each element's index is its own root:
            // _id is the ID of the root (parent) element
        }

        /**
         * Changes element's parent pointers until reach the root
         * @param i Element's index
         * @return Index of the canonical root element
         */
        protected int Root(int i)
        {
            // chain-like changing the roots
            // while the i-th element index is not an index of its root
            while (i != _id[i])
            {
                // to point every other node to its super-parent (the very main parent)
                _id[i] = _id[_id[i]];
                // jump to the root of i-th element
                i = _id[i];
            }
            return i;
        }

        // make the p-th element to be a child of q-th element's parent
        // union(4, 3) = 4 is a child of 3's root (parent) element
        override protected void _CallUnion(int p, int q)
        {
            // get the root elements of q-th and q-th elements
            int rootP = Root(p);
            int rootQ = Root(q);
            if (rootP == rootQ) return;

            // make the root of p-the element a child of q-ths parent
            _id[rootP] = rootQ;
        }

        override protected bool _CallConnected(int p, int q)
        {
            // they have the same root (parent) element
            return Root(p) == Root(q);
        }
    }
}
