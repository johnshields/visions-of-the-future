using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float movementSpeed; // creates a variable that controls the movement speed
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;


    public Vector3 newPosition; // sets the position of the camera rig
    public Quaternion newRotation; // sets the rotation of the camera rig
    public Vector3 newZoom;



    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position; // sets the default position of the camera rig as its current position
        newRotation = transform.rotation; // sets the default rotation of the camera rig as its current rotation
        newZoom = cameraTransform.localPosition; // sets the zoom as the current local transform position of the camera. Local position is used so the camera stays relative to the rig.
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput(); // calls the HandleMovementInput function
        HandleMouseInput();
    }

    public void HandleMovementInput() // handles the keyboard movement inputs
    {
        if(Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * movementSpeed); // sets the position of the camera rig as the position defined by the transform forward multiplied by the speed of the transform.
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -movementSpeed); // multiplying the forward movement by a negative speed makes the rig go backwards.
        }

        if(Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed);
        }

        if(Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        
        if(Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); // creats a smooth transition between the original position of the camera rig and its new position
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }

    public void HandleMouseInput() // handles the mouse inputs
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
