using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController80s : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.15f;

    void Start()
    {
        //Finds target object and sets initial offset
        target = GameObject.FindGameObjectWithTag("Player1980").transform;
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        //Updates target position with chosen offset
        var targetPosition = target.position + offset;
        //Smoothly transforms current location to new target position using the Lerp function and smoothSpeed variable
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
