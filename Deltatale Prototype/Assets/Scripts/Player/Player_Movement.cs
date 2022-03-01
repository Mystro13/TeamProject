using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1;

    [SerializeField]
    float jumpForce = 1;

    Rigidbody rb;

    [SerializeField]
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + h * Time.deltaTime * moveSpeed,
                                         transform.position.y,
                                         transform.position.z + v * Time.deltaTime * moveSpeed);

        rb.velocity = new Vector3(h * moveSpeed,
                                   rb.velocity.y,
                                   v * moveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,
                                  jumpForce,
                                  rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            isGrounded = true;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            isGrounded = false;
        }
    }
}