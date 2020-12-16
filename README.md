# Assignment-8 A star Algorithm

* Shir Avraham
* Yuval Zarbiv
* Matti Stern

**On this part we implemented the algorithm A star.**


## Section 2 - A star Algorithm

We create 2 generic scripts :
[Astar](https://github.com/MYS-games/Assignment-week8/blob/master/Assets/Scripts/3-Astar/Astar.cs) And
[PriorityQueue](https://github.com/MYS-games/Assignment-week8/blob/master/Assets/Scripts/3-Astar/PriorityQueue.cs)

we also expend the Igraph interface : [IGraph](https://github.com/MYS-games/Assignment-week8/blob/master/Assets/Scripts/0-graph/IGraph.cs) and implements it on [TilemapGraph](https://github.com/MYS-games/Assignment-week8/blob/master/Assets/Scripts/0-graph/TilemapGraph.cs).

The algorithm finds best path from start node to end node, it considerate the tiles weights on every step.
The priority Queue we create works different from the known priority queue, the best priority is the lowest.
We added distance and weight functions:

* the distance function returns the Heuristics distance between 2 given nodes.
* the get weight function returns the weight of the next neighbor tile.

