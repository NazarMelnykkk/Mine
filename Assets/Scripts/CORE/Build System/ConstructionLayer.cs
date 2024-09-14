using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructionLayer : TilemapLayer
{

    private Dictionary<Vector3Int, Buildable> _buildables = new();

    public void Build(Vector3 worldCoords, BuildableItem item)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        var buildable = new Buildable(item, coords, _tilemap);

        if (item.Tile != null) 
        {
            var tileChangeData = new TileChangeData(coords, item.Tile, Color.white, Matrix4x4.Translate(item.TileOffset));

            _tilemap.SetTile(tileChangeData, false);

            _tilemap.SetTile(coords, item.Tile);
        }

        _buildables.Add(coords, buildable);

        
    }

    public bool IsEmpty(Vector3 worldCoords)
    {
        var coords = _tilemap.WorldToCell(worldCoords);
        return !_buildables.ContainsKey(coords);
    }
}
