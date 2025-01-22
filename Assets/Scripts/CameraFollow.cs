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
        // Поворот камеры с помощью сенсора
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                yaw += touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                pitch -= touch.deltaPosition.y * rotationSpeed * Time.deltaTime;
                pitch = Mathf.Clamp(pitch, -20f, 80f); // Ограничиваем угол наклона
            }
        }

        // Плавное следование камеры
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Поворот камеры в направлении цели с учётом касания
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
