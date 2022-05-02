using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAudioManager : MonoBehaviour
{
    public static CityAudioManager instance;

    public void Awake()
    {
        instance = this;

    }

    private AudioSource source;


    public AudioClip[] buildSounds;
    public AudioClip[] destroySounds;
    

    public float pitchChange;
    


    public void Start()
    {
        source = GetComponent<AudioSource>();       
    }

    public void BuildSoundPlay()
    {
        source.clip = buildSounds[Random.Range(0, buildSounds.Length)];
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange);
       

        source.PlayOneShot(source.clip);
    }

    public void DestroySoundPlay()
    {
        source.clip = destroySounds[Random.Range(0, destroySounds.Length)];
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange);
       
        source.PlayOneShot(source.clip);
    }    
}
