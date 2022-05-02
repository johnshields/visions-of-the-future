using UnityEngine;

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

    public static void FadeMusic(bool fadeIn, bool fadeOut)
    {
        _animator.SetBool(_fadeIn, fadeIn);
        _animator.SetBool(_fadeOut, fadeOut);
    }
}
