using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook80s : MonoBehaviour
{
    [SerializeField] float sensitivityX = 250f;
    [SerializeField] float sensitivityY = 200f;
    float mouseX;
    float mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85.0f;
    float xRotation = 0f;

    private bool interactToggle;

    void Start()
    {
        //Locks cursor to centre of the screen and hides
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //When "P" key is pressed switch the interact toggle
        if (Input.GetKeyDown("p"))
        {
            interactToggle = !interactToggle;
        }

        //When interactToggle is set to false, call mouse look function
        if (!interactToggle) {
            MouseLook();
        }

        //When interactToggle is set to true, call mouse local interaction function
        if (interactToggle) {
            MouseLocalInteraction();
        }
    }

    //Simple mouse look script that updates camera rotation with mouse movement
    void MouseLook() 
    {
        Cursor.lockState = CursorLockMode.Locked;

        mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerCamera.Rotate(Vector3.up * mouseX);
    }

    //Removes cursor lock state so user can interact with the in world canvas space
    void MouseLocalInteraction() 
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
