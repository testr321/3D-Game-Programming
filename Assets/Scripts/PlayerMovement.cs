using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canFly;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    public float moveSpeed = 5f;
    public float gravity = -20;
    public float jumpHeight = 1f;

    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
            canFly = !canFly;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);
    
        if (canFly)
        {
            if (Input.GetButton("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else if (Input.GetKey("left ctrl") || Input.GetKey("left shift"))
            {
                velocity.y = -Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else
            {
                velocity.y = 0;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
        }
        

        controller.Move(velocity * Time.deltaTime);
    }
}
