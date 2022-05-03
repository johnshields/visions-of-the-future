using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAudioManager : MonoBehaviour
{
    // singleton pattern

    public static CityAudioManager instance;

    public void Awake()
    {
        instance = this;

    }

    private AudioSource source; // creates an audiosource that gets assigned in the inspector


    public AudioClip[] buildSounds; // creates an array of audioclips
    public AudioClip[] destroySounds; // creates an array of audioclips
    

    public float pitchChange; // creates a float
    


    public void Start()
    {
        source = GetComponent<AudioSource>();  // gets the audiosource component attached to the gameobject     
    }

    public void BuildSoundPlay() // plays the build sounds
    {
        source.clip = buildSounds[Random.Range(0, buildSounds.Length)]; // the clip in the audio source is a randomly assigned cli in the buildSounds array
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange); // the pitch of the audio clip assigned to the audiosource is given a value +.02 or -.02 of 1
       

        source.PlayOneShot(source.clip); // plays the audioclip assigned to the audiosource
    }

    public void DestroySoundPlay() // plays the destroy sounds
    {
        source.clip = destroySounds[Random.Range(0, destroySounds.Length)];
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange);
       
        source.PlayOneShot(source.clip);
    }    
}
