using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A graph that represents a tilemap, using only the allowed tiles.
 */
public class TilemapGraph : IGraph<Vector3Int>
{
    private Tilemap tilemap;
    private TileBase[] allowedTiles;

    public TilemapGraph(Tilemap tilemap, TileBase[] allowedTiles)
    {
        this.tilemap = tilemap;
        this.allowedTiles = allowedTiles;
    }

    static Vector3Int[] directions = {
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(0, 1, 0),
    };

    public IEnumerable<Vector3Int> Neighbors(Vector3Int nodePosition)
    {
        foreach (var direction in directions)
        {
            Vector3Int neighborPos = nodePosition + direction;
            TileBase neighborTile = tilemap.GetTile(neighborPos);
            if (allowedTiles.Contains(neighborTile))
                yield return neighborPos;
        }
    }

    public float getDistance(Vector3Int nodePos, Vector3Int endPos)
    {
        return Vector3.Distance(nodePos, endPos);
    }

    public float getWeight(Vector3Int nextNode)
    {
        return 1f;
    }
}
