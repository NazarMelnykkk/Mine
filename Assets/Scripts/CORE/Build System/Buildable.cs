using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Buildable 
{
    [field: SerializeField] public Tilemap ParentTileMap { get; private set; }
    [field: SerializeField] public BuildableItem BuildableType { get; private set; }
    [field: SerializeField] public GameObject GameObject { get; private set; }
    [field: SerializeField] public Vector3Int Coordinates { get; private set; }


    public Buildable(BuildableItem type, Vector3Int coords, Tilemap tilemap, GameObject gameObject = null)
    {
        ParentTileMap = tilemap;
        BuildableType = type;
        Coordinates = coords;
        GameObject = gameObject;
    }
}
