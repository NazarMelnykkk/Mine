using System.Collections;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{

    [field: SerializeField] public BuildableItem ActiveBuildable {  get; private set; }

    [SerializeField] private float _maxBuildingDistance = 3f;
    [SerializeField] private ConstructionLayer _constructionLayer;
    [SerializeField] private PreviewLayer _previewLayer;

    private Coroutine _buildCoroutine;

    public bool BuildState = false;
    public bool CanPlace = false;

    private void OnEnable()
    {
        References.Instance.InputController.OnFire1PerformedEvent += Build;
        References.Instance.InputController.OnFire2PerformedEvent += TurnBuildState;
    }

    private void OnDisable()
    {
        References.Instance.InputController.OnFire1PerformedEvent -= Build;
        References.Instance.InputController.OnFire2PerformedEvent -= TurnBuildState;
    }

    private void TurnBuildState()
    {
        //other logic (have placing item? if not => return)

        if (ActiveBuildable == null && _constructionLayer == null)
        {
            return;
        }

        BuildState = !BuildState;

        if (BuildState == true)
        {
            OnBuilding();
        }
        else
        {
            OffBuilding();
        }
    }

    private void OnBuilding()
    {
        if (_buildCoroutine == null)
        {
            _buildCoroutine = StartCoroutine(BuildCoroutine());
        }
        else
        {
            Debug.LogError("Place coroutine is not stopped!");
        }
    }

    private void OffBuilding()
    {
        if (_buildCoroutine != null)
        {
            Debug.LogError("Stop placing");
            StopCoroutine(_buildCoroutine);
            _previewLayer.ClearPreview();
            CanPlace = false;
            _buildCoroutine = null;
        }
    }

    private void Build()
    {
        if (CanPlace == true)
        {
            _constructionLayer.Build(References.Instance.InputController.MouseInWorldPosition, ActiveBuildable);
        }  
    }


    private IEnumerator BuildCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(DelayConstants.DELAY_01);

            var mousePos = References.Instance.InputController.MouseInWorldPosition;          
            if (IsMouseWithinBuildableRange() == true )
            {
                if (_constructionLayer.IsEmpty(mousePos))
                {
                    CanPlace = true;
                }
                else
                {
                    CanPlace = false;
                }
                _previewLayer.ShowPreview(ActiveBuildable, mousePos, _constructionLayer.IsEmpty(mousePos));
            }
            else
            {
                _previewLayer.ClearPreview();
                CanPlace = false;
            }

/*            if (ActiveBuildable == null)
            {
                _previewLayer.ClearPreview();
                CanPlace = false;
            }*/
        }
    }

    private bool IsMouseWithinBuildableRange()
    {
        return Vector3.Distance(References.Instance.InputController.MouseInWorldPosition, transform.position) <= _maxBuildingDistance;
    }


}
