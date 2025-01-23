using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Цель (персонаж)
    public Vector3 offset; // Смещение камеры
    public float smoothSpeed = 0.125f; // Скорость сглаживания

    private float pitch = 2f; // Угол наклона камеры
    private float yaw = 0f; // Угол поворота камеры

    public float rotationSpeed = 5f; // Скорость вращения камеры

    void LateUpdate()
    {

        // Плавное следование камеры
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
