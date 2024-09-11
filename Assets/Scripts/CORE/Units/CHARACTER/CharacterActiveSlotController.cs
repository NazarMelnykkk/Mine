using UnityEngine;

public class CharacterActiveSlotController : MonoBehaviour
{
    [SerializeField] private ItemActionType actionType;

    [SerializeField] private TileHandler _tileHandler;


    private void Start()
    {
        
    }

    private void FindTileHandler()
    {
        _tileHandler = FindObjectOfType<TileHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_tileHandler == null) 
            {
                FindTileHandler();
            }

            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
            _tileHandler.IsInteractable(position);

        }
    }

}
