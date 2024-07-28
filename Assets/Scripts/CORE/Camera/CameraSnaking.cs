using System.Collections;
using UnityEngine;

public class CameraSnaking : MonoBehaviour
{
    //[]
    public IEnumerator Snake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector2 originalPosition = transform.position;
            float x = originalPosition.x + Random.Range(-1f, 1f) * magnitude;
            float z = originalPosition.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector2(x, originalPosition.y);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
