using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] private float _smoothTime = 0.9f;
    private Vector3 _offset;

    private Vector2 _velocity = Vector2.zero;
    private GameObject _target;

    [Header("Zoom")]
    private float _zoomSpeed = 0.1f;
    private float _maxZoom = 6;
    private float _minZoom = 3;


    private void Start()
    {
        Initialize();
        References.Instance.InputController.OnScrollPerformedIvent += Zoom;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public void Initialize()
    {
        _offset = transform.position;
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            Follow();
        }
    }

    #region Follow

    private void Follow()
    {
        if (_target != null)
        {
            Vector3 targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y + _offset.y);

            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
    }

    #endregion

    #region Zoom

    private void Zoom(float delta)
    {
        float newZoom = Mathf.Clamp(_offset.z - delta * _zoomSpeed, _minZoom, _maxZoom);
        _offset.z = newZoom;
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newZoom, _zoomSpeed);
    }


    #endregion

}

