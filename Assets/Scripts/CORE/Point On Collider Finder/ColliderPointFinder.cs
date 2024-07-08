using System.Collections.Generic;
using UnityEngine;

public class ColliderPointFinder : MonoBehaviour
{
    private int _maxAttempts = 100;
    private Vector3 _colliderCheckSize = new Vector3(0.1f, 1, 0.1f);

    private int _colliderIndex = 0;

    [SerializeField] private List<Collider> _spawnColliders;
    [SerializeField] private LayerMask _excludeLayerMask;

    public Vector3 GetRandomPoint()
    {
        return FindPoint(_spawnColliders);
    }

    public Vector3 FindPoint(List<Collider> colliders)
    {
        _colliderIndex = 1;

        for (int i = 0; i < _maxAttempts; i++)
        {

            if (_colliderIndex >= colliders.Count)
            {
                _colliderIndex = 0;
            }

            float posX = Random.Range(colliders[_colliderIndex].transform.position.x - Random.Range(0, colliders[_colliderIndex].bounds.extents.x), colliders[_colliderIndex].transform.position.x + Random.Range(0, colliders[_colliderIndex].bounds.extents.x));
            float posZ = Random.Range(colliders[_colliderIndex].transform.position.z - Random.Range(0, colliders[_colliderIndex].bounds.extents.z), colliders[_colliderIndex].transform.position.z + Random.Range(0, colliders[_colliderIndex].bounds.extents.z));
            Vector3 spawnPos = new Vector3(posX, 1.15f, posZ);

            //return spawnPos;

            if (CheckSpawnPoint(spawnPos))
            {
                return spawnPos;
            }

            _colliderIndex++;
        }

        Debug.LogError("Failed to find a valid spawn position after " + _maxAttempts + " attempts");
        return Vector3.zero;
    }

    private bool CheckSpawnPoint(Vector3 spawnPos)
    {
        Collider[] colliders = Physics.OverlapBox(spawnPos, _colliderCheckSize, Quaternion.identity, ~_excludeLayerMask);
        return colliders.Length == 0;
    }
}
