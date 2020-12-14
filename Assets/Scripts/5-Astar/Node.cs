using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector3Int position;
    public Node parent;
    public float costFromStart, costFromEnd, totalCost;

    public Node(Vector3Int position, float totalCost = 1)
    {
        this.position = position;
        this.parent = null;
        this.costFromStart = 1;
        this.costFromEnd = -1;
        this.totalCost = totalCost;
    }
    public float currentCost
    {
        get
        {
            if (costFromEnd != -1 && totalCost != -1)
                return costFromEnd + totalCost;
            else
                return -1;
        }
    }
}
