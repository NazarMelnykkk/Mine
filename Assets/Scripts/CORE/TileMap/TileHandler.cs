using UnityEngine;
using UnityEngine.Tilemaps;

public class TileHandler : MonoBehaviour
{

    [SerializeField] private Tilemap _interactableTileMap;
    [SerializeField] private Tile _hiddenInteractableTile;


    private void Start()
    {
        foreach (var position in _interactableTileMap.cellBounds.allPositionsWithin)
        {
            _interactableTileMap.SetTile(position, _hiddenInteractableTile);
        }
    }


    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = _interactableTileMap.GetTile(position);

        if (tile != null)
        {
            Debug.LogError(tile.name);
            if (tile.name == "Hidden_Interactable_Ground_Tiles")
            {
                return true;
            }

        }

        return false;
    }
}
