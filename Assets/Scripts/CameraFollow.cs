using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Цель (персонаж)
    public Vector3 offset; // Смещение камеры
    public float smoothSpeed = 0.125f; // Скорость сглаживания

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
