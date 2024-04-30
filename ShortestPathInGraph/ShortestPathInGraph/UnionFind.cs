using System.Collections.Generic;
namespace ShortestPathInGraph;

internal class UnionFind
{
    protected int[] _id;

    public UnionFind(int n)
    {
        _id = new int[n];

        for (int i = 0; i < n; i++)
        {
            _id[i] = i;
        }
    }

    public void Union(int p, int q)
    {
        int pCluster = _id[p];
        int qCluster = _id[q];

        for (int i = 0; i < _id.Length; i++)
        {
            if (_id[i] == pCluster)
            {
                _id[i] = qCluster;
            }
        }
    }

    public bool Connected(int p, int q)
    {
        return _id[p] == _id[q];
    }

    protected void _CallUnion(int p, int q)
    {
        int pCluster = _id[p];
        int qCluster = _id[q];

        for (int i = 0; i < _id.Length; i++)
        {
            if (_id[i] == pCluster)
            {
                _id[i] = qCluster;
            }
        }
    }

    protected bool _CallConnected(int p, int q)
    {
        return _id[p] == _id[q];
    }

    // public override string ToString()
    // {
    //     StringBuilder str = new StringBuilder();
    //     foreach (int id in _id)
    //     {
    //         str.Append(id).Append(" ");
    //     }
    //     return str.ToString();
    // }

    public void Print()
    {
        Console.WriteLine(this.ToString());
    }
}