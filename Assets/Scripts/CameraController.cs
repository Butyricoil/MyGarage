using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public RectTransform touchPanel; // Панель для отслеживания касаний
    public float rotationSpeed = 0.2f; // Скорость вращения камеры

    private Vector2 lastTouchPosition; // Последняя позиция касания
    private bool isTouching = false;   // Проверка, активен ли ввод

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Проверяем, находится ли касание в области панели
            if (IsTouchWithinPanel(touch.position))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    lastTouchPosition = touch.position;
                    isTouching = true;
                }
                else if (touch.phase == TouchPhase.Moved && isTouching)
                {
                    Vector2 deltaPosition = touch.deltaPosition;

                    // Получаем текущий угол вращения по оси Y
                    float currentRotationY = transform.eulerAngles.y;

                    // Инвертируем поворот по оси X, если камера смотрит на заднюю часть (более 180 градусов)
                    if (currentRotationY > 90f && currentRotationY < 270f)
                    {
                        deltaPosition.y = -deltaPosition.y; // Инвертируем поворот по оси X
                    }

                    // Поворачиваем камеру
                    float rotationX = (deltaPosition.y * rotationSpeed);
                    float rotationY = (deltaPosition.x * rotationSpeed);

                    transform.Rotate(-rotationX, rotationY, 0, Space.World);

                    // Ограничиваем вращение камеры
                    Vector3 currentRotation = transform.eulerAngles;
                    currentRotation.z = 0;
                    transform.eulerAngles = currentRotation;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isTouching = false;
                }
            }
        }
    }

    // Проверка, находится ли касание в области панели
    private bool IsTouchWithinPanel(Vector2 touchPosition)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            touchPanel,
            touchPosition,
            null, // Камера, используется null для экрана Canvas
            out localPoint
        );
        return touchPanel.rect.Contains(localPoint);
    }
}
