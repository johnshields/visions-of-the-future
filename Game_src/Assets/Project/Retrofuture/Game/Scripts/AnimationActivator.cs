using UnityEngine;

public class AnimationActivator : MonoBehaviour
{
    private Animator _animator;
    private int animationActive;
    public string parameter;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        animationActive = Animator.StringToHash(parameter);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Animation active..");
        _animator.SetTrigger(animationActive);
    }
}