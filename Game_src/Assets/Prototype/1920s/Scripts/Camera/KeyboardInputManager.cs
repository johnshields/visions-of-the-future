using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : InputManager
{
    // Events

    public static event MoveInputHandler OnMoveInput;
    public static event RotateInputHander OnRotateInput;
    public static event ZoomInputHandler OnZoomInput;

    // Update is called once per frame
    void Update()
    {

        //forwards, backwards, right, left movement

        if (Input.GetKey(KeyCode.W))
        {
            OnMoveInput?.Invoke(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            OnMoveInput?.Invoke(-Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnMoveInput?.Invoke(-Vector3.right);
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnMoveInput?.Invoke(Vector3.forward);
        }


        // Rotation

        if (Input.GetKey(KeyCode.Q))
        {
            OnRotateInput?.Invoke(-1f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            OnRotateInput?.Invoke(1f);
        }


        // Zoom

        if (Input.GetKey(KeyCode.Z))
        {
            OnZoomInput?.Invoke(-1f);
        }

        if (Input.GetKey(KeyCode.X))
        {
            OnZoomInput?.Invoke(1f);
        }

    }
}
