using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideAudio : MonoBehaviour
{
    public static GuideAudio instance;

    public AudioClip textSpeech;
    public AudioClip returnMenuSpeech;
    public AudioClip miniGameMenuSpeech;


    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlayTextSpeech()
    {
        source.clip = textSpeech;
        source.PlayOneShot(source.clip);
    }

    public void PlayReturnMenuSpeech()
    {
        source.clip = returnMenuSpeech;
        source.PlayOneShot(source.clip);
    }

    public void PlayMiniGameSpeech()
    {
        source.clip = miniGameMenuSpeech;
        source.PlayOneShot(source.clip);
    }
}
