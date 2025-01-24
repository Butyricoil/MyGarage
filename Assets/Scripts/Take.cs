using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    float distance = 5;
    public Transform pos;
    private Rigidbody rb;
    private PlayerController player;
    private void Start()
    {

        rb =  GetComponent<Rigidbody>();
        player =  GameObject.Find("First person controller").GetComponent<PlayerController>();
    }
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance) && player.Take==false)
        {
            rb.isKinematic = true;
            player.Take = true;
            rb.MovePosition(pos.position);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKey(KeyCode.G))
            {
                player.Take = false;
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
