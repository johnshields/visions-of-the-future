using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; // sets camera speed

    private bool doMovement = true;

    public float scrollSpeed = 5f;

    public float minY = 10f;

    public float maxY = 80f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if the 'esc' key is pressed then camera movement is disabled
            doMovement = !doMovement;

        if (!doMovement)
            return;


        if (Input.GetKey("w"))// if the w is pressed
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); 
            // camera moves forward when w is being pressed, speed at which is defined above, using global space rather than the co-ordinates of the camera (camera is angled down so would zoom in rather than move forward)
        }

        if (Input.GetKey("s"))// if the s is pressed
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d"))// if the d is pressed
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

         if (Input.GetKey("a"))// if the a is pressed
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel"); // gets the input from the mouse scroll wheel, converts it into a float value. The speed of the scroll effects speed of the zoom.

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp (pos.y, minY, maxY); // restricts the camera scroll

        transform.position = pos;
    
    }
}
