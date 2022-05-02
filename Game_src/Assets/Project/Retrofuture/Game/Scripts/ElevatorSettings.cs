using UnityEngine;

/*
 * ElevatorSettings
 * Script to disable Elevator collider (stop repeating audio).
 */
public class ElevatorSettings : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
