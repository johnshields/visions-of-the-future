using UnityEngine;

/*
 * DriveController
 * Script to play Driving Animation.
 */
public class DriveController : MonoBehaviour
{
    private int _driveActive;
    public Animator animator;
    public GameObject particle;

    private void Start()
    {
        _driveActive = Animator.StringToHash("DriveActive");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Driving car...");
        animator.SetTrigger(_driveActive);
        particle.SetActive(true);
    }
}