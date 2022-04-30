using System;
using UnityEngine;

public class ElevatorSettings : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
