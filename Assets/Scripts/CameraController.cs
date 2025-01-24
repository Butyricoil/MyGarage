using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public RectTransform touchPanel;
    public bool Take;
    public float rotationSpeed = 0.2f;

    private Vector2 lastTouchPosition;
    private bool isTouching = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

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

                     float currentRotationY = transform.eulerAngles.y;

                     if (currentRotationY > 90f && currentRotationY < 270f)
                    {
                        deltaPosition.y = -deltaPosition.y;
                    }

                     float rotationX = (deltaPosition.y * rotationSpeed);
                    float rotationY = (deltaPosition.x * rotationSpeed);

                    transform.Rotate(-rotationX, rotationY, 0, Space.World);

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


    private bool IsTouchWithinPanel(Vector2 touchPosition)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            touchPanel,
            touchPosition,
            null,
            out localPoint
        );
        return touchPanel.rect.Contains(localPoint);
    }
}
