using UnityEngine;

/*
 * NavHubAudio
 * Script for controlling the NavHub's Audio.
 */
public class NavHubAudio : MonoBehaviour
{
    private static int _fadeIn, _fadeOut;
    private static Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fadeIn = Animator.StringToHash("FadeIn");
        _fadeOut = Animator.StringToHash("FadeOut");

        FadeMusic(true, false);
    }
    
    // Function with param to change Fade - (used in other scripts). 
    public static void FadeMusic(bool fadeIn, bool fadeOut)
    {
        _animator.SetBool(_fadeIn, fadeIn);
        _animator.SetBool(_fadeOut, fadeOut);
    }
}
