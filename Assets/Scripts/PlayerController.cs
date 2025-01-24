using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;
    public Camera playerCamera;
    public bool Take;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

         Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

         forward.y = 0f;
        right.y = 0f;

         forward.Normalize();
        right.Normalize();

         Vector3 direction = forward * vertical + right * horizontal;

        if (direction.magnitude >= 0.1f)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}