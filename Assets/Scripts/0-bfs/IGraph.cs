﻿using System.Collections.Generic;

/**
 * An abstract graph.
 * It does not use any memory.
 * It only has a single abstract function Neighbors, that returns the neighbors of a given node.
 * T = type of node in graph.
 * @author Erel Segal-Halevi
 * @since 2020-12
 */
public interface IGraph<N> {
    IEnumerable<N> Neighbors(N position);

    float getDistance(N myPos, N endPos);

    float getWeight(N nextNode); 
}
