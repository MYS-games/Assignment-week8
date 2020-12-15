using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using UnityEngine;


public class Astar
{

    public static void FindPath<NodeType>(
        IGraph<NodeType> graph,
        NodeType startNode,
        NodeType endNode,
        List<NodeType> outputPath,
        int maxiterations = 1000)
    {

        Dictionary<NodeType, NodeType> parent = new Dictionary<NodeType, NodeType>();

        //Dictionary<NodeType, float> nodeWeights = new Dictionary<NodeType, float>();
        PriorityQueue<NodeType> priorityQueue = new PriorityQueue<NodeType>();
        HashSet<NodeType> closed = new HashSet<NodeType>();

        priorityQueue.Enqueue(startNode, graph.getDistance(startNode, endNode));

        NodeType current;



       for(int i = 0; i < maxiterations; i++) {
            Debug.Log(priorityQueue);

            Debug.Log(i);
            if(priorityQueue.Size == 0)
            {
                break;
            }
            else
            {
                current = priorityQueue.Peek();

                if (current.Equals(endNode))
                {
                    outputPath.Add(endNode);
                    while (parent.ContainsKey(current))
                    {
                        current = parent[current];
                        outputPath.Add(current);
                    }
                    outputPath.Reverse();
                    break;
                }
                else
                {
                    foreach (var neighbor in graph.Neighbors(current))
                    {
                        float nextWeight = graph.getWeight(neighbor) + priorityQueue.getWeight(current) + graph.getDistance(neighbor, endNode);

                        if (closed.Contains(neighbor))
                        {
                            if (priorityQueue.getWeight(neighbor) > nextWeight)
                            {
                                priorityQueue.setWeight(neighbor, nextWeight);
                                parent[neighbor] = current;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        priorityQueue.Enqueue(neighbor, nextWeight);
                        parent[neighbor] = current;
                    }
                    closed.Add(current);
                    priorityQueue.Dequeue();
                }
            }

           
        }
    }

    public static List<NodeType> GetPath<NodeType>(IGraph<NodeType> graph, NodeType startNode, NodeType endNode, int maxiterations = 1000)
    {
        List<NodeType> path = new List<NodeType>();
        FindPath(graph, startNode, endNode, path, maxiterations);
        return path;
    }
}