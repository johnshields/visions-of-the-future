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
        source.clip = uiSounds[Random.Range(0, uiSounds.Length)]; // the clip in the audio source is a randomly assigned one fron uiSounds array
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange); // randomises the pitch, plus and minus the pitchchange value

        source.PlayOneShot(source.clip); // plays the audioclip assigend to the audiosource
    }

    
}
