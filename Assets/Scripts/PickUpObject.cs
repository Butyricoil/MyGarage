using UnityEngine;

public class Take : MonoBehaviour
{
    private bool isPickedUp = false;
    private Vector3 pickupPosition;
    private Transform originalParent;

    void Start()
    {
        originalParent = transform.parent;
    }

    void Update()
    {
        // Поднимаем предмет, если он поднят
        if (isPickedUp)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    public void PickUpObject()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            pickupPosition = transform.position;
            transform.SetParent(null); // Открепляем от родителя
        }
        else
        {
            isPickedUp = false;
            transform.SetParent(originalParent); // Возвращаем к исходному родителю
            transform.position = pickupPosition; // Возвращаем на исходную позицию
        }
    }
}