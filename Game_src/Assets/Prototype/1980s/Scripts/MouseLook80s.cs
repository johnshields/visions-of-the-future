using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook80s : MonoBehaviour
{
    [SerializeField] float sensitivityX = 130f;
    [SerializeField] float sensitivityY = 100f;
    float mouseX;
    float mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85.0f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);


        //Vector3 targetRotation = transform.eulerAngles;
        //targetRotation.x = xRotation;
        //playerCamera.eulerAngles = targetRotation;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerCamera.Rotate(Vector3.up * mouseX);        
    }
}
