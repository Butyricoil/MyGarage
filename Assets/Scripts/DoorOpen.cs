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
        }

        if (anim != null)
        {
            anim.SetBool("isOpen", true); // Дверь открывается при запуске игры
            Debug.Log("Door animation started");
        }
        else
        {
            Debug.LogError("Animator not found on door object");
        }
    }
}