using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator not found on door object");
            return;
        }

        // Запускаем анимацию открытия двери
        anim.SetBool("isOpen", true);
        Debug.Log("Door animation started");
    }
}