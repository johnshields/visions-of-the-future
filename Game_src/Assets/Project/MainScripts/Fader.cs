using UnityEngine;

/*
 * Fader
 * Script for control the black FadeIn/FadeOut used throughout the scenes.
 */
public class Fader : MonoBehaviour
{
    private static int _fadeIn, _fadeOut;
    private static Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fadeIn = Animator.StringToHash("FadeIn");   
        _fadeOut = Animator.StringToHash("FadeOut");

        CallFader(true, false);
    }

    public static void CallFader(bool fadeIn, bool fadeOut)
    {
        _animator.SetBool(_fadeIn, fadeIn);
        _animator.SetBool(_fadeOut, fadeOut);
    }
}
