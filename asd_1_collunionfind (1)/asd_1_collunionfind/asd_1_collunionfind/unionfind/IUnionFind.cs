using asd_1_collunionfind.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_1_collunionfind.unionfind
{
    internal interface IUnionFind
    {
        /// <summary>
        /// Connects p-th element to q-th element
        /// </summary>
        /// <param name="p">Index of an element to be connected</param>
        /// <param name="q">Index of an element to connect to</param>
        void Union(int p, int q);

        /// <summary>
        /// Checks whether two elements are connected
        /// </summary>
        /// <param name="p">Index of the element</param>
        /// <param name="q">Index of another element</param>
        /// <returns>The status of connection</returns>
        bool Connected(int p, int q);

        /// <summary>
        /// Makes a string of current connectivity pattern
        /// </summary>
        /// <returns>A string representation of _id</returns>
        string ToString();

        /// <summary>
        /// Print out the data structure to console
        /// </summary>
        void Print();
    }
}
