using System;
using System.Collections.Generic;
using System.Diagnostics;

using IntPair = System.ValueTuple<int, int>;
namespace TestAStar
{
    class IntGraph : IGraph<int>
    {

        public IEnumerable<int> Neighbors(int node)
        {
            yield return node + 1;
            yield return node - 1;
        }

        public float getDistance(int myPos, int endPos)
        {
            return Math.Abs(myPos - endPos);
        }

        public float getWeight(int nextNode)
        {
            return 1;
        }

    }

    class IntPairGraph : IGraph<IntPair>
    {

        public IEnumerable<IntPair> Neighbors(IntPair node)
        {
            yield return (node.Item1, node.Item2 + 1);
            yield return (node.Item1, node.Item2 - 1);
            yield return (node.Item1 + 1, node.Item2);
            yield return (node.Item1 - 1, node.Item2);
        }

        public float getDistance((int, int) myPos, (int, int) endPos)
        {
            return (float)(Math.Sqrt(Math.Pow(myPos.Item1 - endPos.Item1, 2) + Math.Pow(myPos.Item2 - endPos.Item2, 2)));
        }

        public float getWeight((int, int) nextNode)
        {
            return 1f;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Astar Test");

            var intGraph = new IntGraph();
            var path = Astar.GetPath(intGraph, 90, 95);
            var pathString = String.Join(",", path.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "90,91,92,93,94,95");
            path = Astar.GetPath(intGraph, 85, 80);
            pathString = String.Join(",", path.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "85,84,83,82,81,80");

            var intPairGraph = new IntPairGraph();
            var path2 = Astar.GetPath(intPairGraph, (9, 5), (7, 6));
            pathString = String.Join(",", path2.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(9, 5),(9, 6),(8, 6),(7, 6)");

            // Here we should get an empty path because of maxiterations:
            int maxiterations = 1000;
            path2 = Astar.GetPath(intPairGraph, (9, 5), (-7, -6), maxiterations);
            pathString = String.Join(",", path2.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "");

            Console.WriteLine("End AStar Test");
        }
    }

}
