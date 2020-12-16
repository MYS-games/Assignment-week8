using System.Collections.Generic;

/**
 * An abstract graph.
 * It does not use any memory.
 * It only has a single abstract function Neighbors, that returns the neighbors of a given node.
 * T = type of node in graph.
 * @author Erel Segal-Halevi
 * @since 2020-12
 */
public interface IGraph<T>
{
    IEnumerable<T> Neighbors(T position);   //get all neighbors

    float getDistance(T myPos, T endPos);   //get heuristic distance from node to other node

    float getWeight(T nextNode);            //get the weight of a node
}
