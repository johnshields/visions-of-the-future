using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    private AudioSource source;

    public AudioClip[] uiSounds;

     public float pitchChange;
    

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayUiSounds()
    {
        source.clip = uiSounds[Random.Range(0, uiSounds.Length)];
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange);

        source.PlayOneShot(source.clip);
    }

    
}
