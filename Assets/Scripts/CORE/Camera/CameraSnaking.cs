using System.Collections;
using UnityEngine;

public class CameraSnaking : MonoBehaviour
{
    private Coroutine _snakeCoroutine;

    public void Snake(float duration, float magnitude)
    {
        if (_snakeCoroutine != null)
        {
            _snakeCoroutine = StartCoroutine(SnakeCoroutine(duration, magnitude));
        }
    }

    private IEnumerator SnakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector2 originalPosition = transform.position;
            float x = originalPosition.x + Random.Range(-1f, 1f) * magnitude;
            float z = originalPosition.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector2(x, originalPosition.y);

            elapsed += Time.deltaTime;

            _snakeCoroutine = null;
            yield return null;
        }
    }
}
