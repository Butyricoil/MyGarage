using UnityEngine;

public class PlayerControllerWithTouch : MonoBehaviour
{
    public Joystick joystick; // Ссылка на джойстик
    public float moveSpeed = 5f; // Скорость движения
    public float rotationSpeed = 10f; // Скорость вращения

    private Rigidbody rb;
    private Vector2 lastTouchPosition; // Последняя позиция касания
    private bool isRotating = false;   // Флаг, активен ли свайп для поворота

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleRotation(); // Обработка касаний для поворота
    }

    void FixedUpdate()
    {
        MovePlayer(); // Движение персонажа
    }

    void HandleRotation()
    {
        if (Input.touchCount > 0) // Если есть касание
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position; // Сохраняем начальную позицию касания
                isRotating = true;
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                Vector2 deltaPosition = touch.position - lastTouchPosition; // Сдвиг касания
                float angle = deltaPosition.x * rotationSpeed * Time.deltaTime; // Рассчитываем угол вращения

                // Поворачиваем персонажа вокруг оси Y
                transform.Rotate(0f, angle, 0f);

                lastTouchPosition = touch.position; // Обновляем последнюю позицию
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isRotating = false; // Завершаем вращение
            }
        }
    }

    void MovePlayer()
    {
        // Получение значений из джойстика
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Движение персонажа
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 move = transform.forward * direction.magnitude; // Движение в направлении передней оси
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
