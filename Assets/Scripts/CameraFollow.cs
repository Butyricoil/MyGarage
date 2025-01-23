using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private float pitch = 2f;
    private float yaw = 0f;

    public float rotationSpeed = 5f;

    void LateUpdate()
    {

        // Плавное следование камеры
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
