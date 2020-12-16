using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


/*
 * A Star path search with weights
 */
public class Astar
{

    public static void FindPath<NodeType>(
        IGraph<NodeType> graph,
        NodeType startNode,
        NodeType endNode,
        List<NodeType> outputPath,
        int maxiterations = 1000)
    {
        //holds the node that the current node came from
        Dictionary<NodeType, NodeType> parent = new Dictionary<NodeType, NodeType>();

        //generic priority queue, check PriorityQueue.cs
        PriorityQueue<NodeType> priorityQueue = new PriorityQueue<NodeType>();

        HashSet<NodeType> closed = new HashSet<NodeType>();

        priorityQueue.Enqueue(startNode, graph.getDistance(startNode, endNode));
        
        //the node that we are thinking is a part of the path 
        NodeType current;

       for(int i = 0; i < maxiterations; i++) {

            if(priorityQueue.Size == 0)
            {
                break;
            }
            else
            {
                //get the node with the lowest weight
                current = priorityQueue.Peek();

                //we are done, now get the path into output
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
                        //update the neighbors weight
                        float nextWeight = graph.getWeight(neighbor) + priorityQueue.getWeight(current) + graph.getDistance(neighbor, endNode);

                        if (closed.Contains(neighbor))
                        {
                            if (priorityQueue.getWeight(neighbor) > nextWeight)
                            {
                                //if the weight is lower then the prev weight set the best weight
                                priorityQueue.setWeight(neighbor, nextWeight);
                                //update the parent
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
                    //we are done with the current node, dequeue him from the queue
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