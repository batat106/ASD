namespace ShortestPathInGraph;

/// <summary>
/// Represents a node on the grid with its coordinates, cost from the start node, total cost, and parent node.
/// </summary>
public class Node
{
    /// <summary>
    /// The x-coordinate of the node
    /// </summary>
    public readonly int X;

    /// <summary>
    /// The y-coordinate of the node
    /// </summary>
    public readonly int Y;

    /// <summary>
    /// The cost from the start node to this node
    /// </summary>
    public int CostFromStart;

    /// <summary>
    /// The total cost of the node (costFromStart + heuristic)
    /// </summary>
    public int TotalCost;

    /// <summary>
    /// The parent node of this node
    /// </summary>
    public Node Parent;

    /// <summary>
    /// Initializes a new instance of the Node class with the specified x and y coordinates.
    /// </summary>
    /// <param name="x">The x-coordinate of the node</param>
    /// <param name="y">The y-coordinate of the node</param>
    public Node(int x, int y)
    {
        this.X = x;
        this.Y = y;
        this.CostFromStart = int.MaxValue;
        this.TotalCost = int.MaxValue;
        this.Parent = null;
    }
}

public class AStar
{
    /// <summary>
    /// Finds a path on a grid from start node to goal node using A* algorithm
    /// </summary>
    /// <param name="grid">The grid representing the map</param>
    /// <param name="start">The starting node</param>
    /// <param name="goal">The goal node</param>
    /// <returns>The list of nodes representing the path from start to goal</returns>
    public static List<Node> FindPath(int[,] grid, Node start, Node goal)
    {
        // Initialize open and closed sets
        List<Node> openSet = new List<Node>();
        List<Node> closedSet = new List<Node>();

        // Add start node to open set
        openSet.Add(start);

        // Loop until open set is empty
        while (openSet.Count > 0)
        {
            // Find node with lowest total cost in open set
            Node current = openSet[0];
            int currentIndex = 0;
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].TotalCost < current.TotalCost)
                {
                    current = openSet[i];
                    currentIndex = i;
                }
            }

            // Remove current node from open set and add to closed set
            openSet.RemoveAt(currentIndex);
            closedSet.Add(current);

            // Check if current node is the goal node
            if (current.X == goal.X && current.Y == goal.Y)
            {
                // Reconstruct and return path
                List<Node> path = new List<Node>();
                Node node = current;
                while (node != null)
                {
                    path.Add(node);
                    node = node.Parent;
                }

                path.Reverse();
                return path;
            }

            // Get neighbors of current node
            List<Node> neighbors = GetNeighbors(grid, current);

            // Update costs and add neighbors to open set
            foreach (Node neighbor in neighbors)
            {
                int newCost = current.CostFromStart + 1;
                if (newCost < neighbor.CostFromStart || !openSet.Contains(neighbor))
                {
                    neighbor.CostFromStart = newCost;
                    neighbor.TotalCost = newCost + Heuristic(neighbor, goal);
                    neighbor.Parent = current;

                    if (!openSet.Contains(neighbor) && !closedSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        // Return null if no path was found
        return null;
    }

    /// <summary>
    /// Returns a list of neighboring nodes for a given node on a grid
    /// </summary>
    /// <param name="grid">The grid representing the map</param>
    /// <param name="current">The current node to find neighbors for</param>
    /// <returns>A list of neighboring nodes</returns>
    private static List<Node> GetNeighbors(int[,] grid, Node current)
    {
        // Define the possible movements: right, down, left, up
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        List<Node> neighbors = new List<Node>();

        // Check each direction
        for (int i = 0; i < 4; i++)
        {
            int newX = current.X + dx[i];
            int newY = current.Y + dy[i];

            // Verify if the new position is within the bounds and is a valid path
            if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1) &&
                grid[newX, newY] == 0)
            {
                Node neighbor = new Node(newX, newY);
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }


    //     return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

    /// <summary>
    /// Calculates the Euclidean distance heuristic between two nodes
    /// </summary>
    /// <param name="a">The first node</param>
    /// <param name="b">The second node</param>
    /// <returns>The Euclidean distance between the nodes as the heuristic value</returns>
    private static int Heuristic(Node a, Node b)
    {
        // Euclidean distance is calculated by taking the square root of the sum of the squared differences of the x and y coordinates
        return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}