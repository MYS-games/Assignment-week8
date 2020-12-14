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

        //Dictionary<NodeType, List<NodeType>> possiblePaths = new Dictionary<NodeType, List<NodeType>>();
        
        Dictionary<NodeType, float> nodeWeights = new Dictionary<NodeType, float>();
        
        nodeWeights.Add(startNode, graph.getDistance(startNode,endNode));
        List<NodeType> firstPath = new List<NodeType>();
        possiblePaths.Add(startNode, firstPath);

        NodeType current;



       for(int i = 0; i < maxiterations; i++) {
            Debug.Log(i);
            if(nodeWeights.Count == 0)
            {
                break;
            }
            float minWeight = nodeWeights.Min(node => node.Value);
            current = nodeWeights.FirstOrDefault(node => node.Value == minWeight).Key;
            if (i == 37)
            {
                Debug.Log("dskfjsdlfkjsldkflskdhflsjdf");
                foreach (NodeType j in nodeWeights.Keys)
                {
                    Debug.Log("key: " + j + " node weight: " + nodeWeights[j]);
                }

                foreach (NodeType j in possiblePaths.Keys)
                {
                    List<NodeType> temp = possiblePaths[j];
                    foreach (NodeType k in temp)
                    {
                        Debug.Log("key: " + j + " node path: " + k);
                    }
                    Debug.Log("size: " + temp.Count);

                }
            }
            Debug.Log(current);
            foreach (var neighbor in graph.Neighbors(current))
            {
                List<NodeType> nList = possiblePaths[current];
                if (nList.Contains(neighbor))
                {
                    Debug.Log(current + " ------ " + neighbor);
                    continue;
                }
                if(graph.getDistance(current,neighbor) > 1)
                {
                    continue;
                }
                float nextWeight = graph.getWeight(neighbor) + nodeWeights[current] + graph.getDistance(neighbor, endNode);
                if (!nodeWeights.ContainsKey(neighbor))
                {
                    nodeWeights.Add(neighbor, nextWeight);

                    List<NodeType> pathList = possiblePaths[current];
                    pathList.Add(current);
                    if (!possiblePaths.ContainsKey(neighbor))
                    {
                        possiblePaths.Add(neighbor, pathList);

                    }
                }
                else
                {
                    if (nextWeight < nodeWeights[neighbor])
                    {
                        //Debug.Log("lala" + neighbor);

                        nodeWeights[neighbor] = nextWeight;

                        List<NodeType> pathList = possiblePaths[current];
                        pathList.Add(current);
                        possiblePaths[neighbor] = pathList;
                    }
                }
            }
             nodeWeights.Remove(current);
            if (possiblePaths.ContainsKey(endNode))
            {
                outputPath = possiblePaths[endNode];
                break;
            }
        }

        // construct path, if end was not closed return null
        if (!possiblePaths.ContainsKey(endNode))
        {
            Debug.Log("can't find shortest path");
            return;
        }


    }

    public static List<NodeType> GetPath<NodeType>(IGraph<NodeType> graph, NodeType startNode, NodeType endNode, int maxiterations = 1000)
    {
        List<NodeType> path = new List<NodeType>();
        FindPath(graph, startNode, endNode, path, maxiterations);
        return path;
    }
}