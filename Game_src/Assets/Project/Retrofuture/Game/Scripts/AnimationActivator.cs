using UnityEngine;

public class AnimationActivator : MonoBehaviour
{
    private Animator _animator;
    private int animationActive;
    public string parameter;
    public GameObject player;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        animationActive = Animator.StringToHash(parameter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            _animator.SetTrigger(animationActive);   
        }
    }
}
