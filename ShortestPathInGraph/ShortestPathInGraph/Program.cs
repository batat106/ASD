using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPathInGraph
{
    
    
    public class Program
    {
        public static void Main()
        {
            int[,] grid = new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 1, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 }
            };

            Node start = new Node(0, 0);
            Node goal = new Node(4, 4);

            List<Node> path = AStar.FindPath(grid, start, goal);

            if (path != null)
            {
                foreach (Node node in path)
                {
                    Console.WriteLine("[" + node.X + ", " + node.Y + "]");
                }
            }
        }
    }
}