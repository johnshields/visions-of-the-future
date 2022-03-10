using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
   public delegate void MoveInputHandler (Vector3 moveVector);
   public delegate void RotateInputHander (float rotateAmount);
   public delegate void ZoomInputHandler (float zoomAmount);
}
