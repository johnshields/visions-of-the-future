using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController80s : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] float speed = 8f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity;
    bool isGrounded;

    //Removes cursor from screen at start of the scene
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Simple player movement script that updates location with user input and simpe gravity transform
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2.0f;
        }

        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 move = transform.right * -x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
