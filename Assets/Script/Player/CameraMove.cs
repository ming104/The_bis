using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    
    //[SerializeField]private float m_roughness; //거칠기 정도
    //[SerializeField]private float m_magnitude; //움직임 범위

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smootedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smootedPosition;
    }

    // private IEnumerator Shake(float duration)
    // {
    //     float halfDuration = duration / 2;
    //     float elapsed = 0f;
    //     float tick = Random.Range(-10f, 10f);

    //     while (elapsed < duration)
    //     {
    //         elapsed += Time.deltaTime / halfDuration;

    //         tick += Time.deltaTime * m_roughness;
    //         transform.position = new Vector3(
    //             Mathf.PerlinNoise(tick, 0) - .5f,
    //             Mathf.PerlinNoise(0, tick) - .5f,
    //             0f) * m_magnitude * Mathf.PingPong(elapsed, halfDuration);

    //         yield return null;
    //     }
    // }
}
