using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestReach
{
    public static class Dijkstra
    {
        public static List<int> FindShortestDistance(int[,] graph, int source)
        {
            var distance = new List<int>();
            var setOfNodes = new HashSet<int>();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distance.Add(int.MaxValue);
                setOfNodes.Add(i);
            }

            setOfNodes.Remove(0);
            distance[source] = 0;

            while (setOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;
                int minValue = int.MaxValue;

                foreach (var node in setOfNodes)
                {
                    if (distance[node] < minValue)
                    {
                        minNode = node;
                        minValue = distance[node];
                    }
                }

                setOfNodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    minNode = setOfNodes.First();
                }

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistanceToNode = distance[minNode] + graph[minNode, i];
                        if (distance[i] > newDistanceToNode)
                        {
                            distance[i] = newDistanceToNode;
                        }
                    }
                }
            }

            if (distance.FindIndex(ind => ind < 0) != -1)
            {
                for (int i = 0; i < distance.Count; i++)
                {
                    if (distance[i] < 0)
                    {
                        distance[i] = -1;
                    }
                }
            }
            
            distance.RemoveAt(0);
            distance.Remove(0);
            return distance;
        }

        public static void Main(string[] args)
        {
            var iterations = int.Parse(Console.ReadLine());
            for (int i = 0; i < iterations; i++)
            {
                var nodesAndEdgesCount = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                var nodesCount = nodesAndEdgesCount[0];
                var edgesCount = nodesAndEdgesCount[1];
                var adjMatrix = new int[nodesCount + 1, nodesCount + 1];

                for (int edge = 0; edge < edgesCount; edge++)
                {
                    var line = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                    ReadInput(adjMatrix, line);
                }

                var startingNode = int.Parse(Console.ReadLine());
                var result = FindShortestDistance(adjMatrix, startingNode);

                Console.WriteLine(string.Join(" ", result));
            }
        }

        public static void ReadInput(int[,] adjMatrix, List<int> line)
        {
            var incomingNode = line[0];
            var outgoingNode = line[1];
            var weight = line[2];

            var cell = adjMatrix[incomingNode, outgoingNode];

            if (cell == 0 || cell > weight)
            {
                adjMatrix[incomingNode, outgoingNode] = weight;
                adjMatrix[outgoingNode, incomingNode] = weight;
            }
        }
    }
}
