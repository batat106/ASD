using asd_1_collunionfind.unionfind;
using asd_1_collunionfind.utils;

namespace asd_1_collunionfind
{
    internal class MainUnionFind : AbstractRunnableApp
    {
        /**
         * Perform a test on a data structure
         * @param iUnionDS  A data structure
         * @param pairsToConnect  Indices of elements to connect together
         * @param pairsToCheckConnection Indices of elements to check if they are connected
         */
        public void TestTheDataStructure(IUnionFind iUnionDS,
                                                int[,] pairsToConnect,
                                                int[,] pairsToCheckConnection)
        {
            Stopwatch watch = new Stopwatch();

            // connect
            int rowsConnect = pairsToConnect.GetLength(0);
            for (int i = 0; i < rowsConnect; i++)
            {
                iUnionDS.Union(pairsToConnect[i, 0], pairsToConnect[i, 1]);
            }

            // check the connection status
            int rowsCheck = pairsToCheckConnection.GetLength(0);
            for (int i = 0; i < rowsCheck; i++)
            {
                iUnionDS.Connected(pairsToCheckConnection[i, 0], pairsToCheckConnection[i, 1]);
            }

            // print out the final connectivity pattern
            iUnionDS.Print();

            Console.WriteLine($"\nElapsed time = {watch.GetElapsedTime()} [s]");
        }

        override public void Run(string[]? args = null)
        {
            base.Run(args);

            // total elements in the set
            int n = 10;
            int[,] pairsToConnect = { { 4, 3 }, { 3, 8 }, { 9, 4 }, { 2, 1 }, { 5, 0 }, { 7, 2 }, { 6, 1 }, { 7, 3 } };
            int[,] pairsToCheck = { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 0, 9 }, { 3, 9 } };

            // UnionFind data struct based on "Eager" QuickFind algorithm
            Console.WriteLine("\nUnionFind:\n");
            TestTheDataStructure(new UnionFind(n), pairsToConnect, pairsToCheck);

            // UnionFind data struct based on "Lazy" QuickUnion algorithm
            Console.WriteLine("\nUnionFindQU:\n");
            TestTheDataStructure(new UnionFindQU(n), pairsToConnect, pairsToCheck);

            // UnionFind data struct based on "Lazy" QuickUnion algorithm,
            // with weighted tree size - based connection
            Console.WriteLine("\nUnionFindQUWeighted:\n");
            TestTheDataStructure(new UnionFindQUWeighted(n), pairsToConnect, pairsToCheck);
        }
    }
}
