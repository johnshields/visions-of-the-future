using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{

    private Animator _animator;
    private int _elevatorActive;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _elevatorActive = Animator.StringToHash("ElevatorActive");
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger(_elevatorActive);
    }
}
