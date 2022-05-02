using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public void Awake()
    {
        instance = this;

    }


    ScoreManager scoreManager;

    private AudioSource source;


    public AudioClip[] buildSounds;
    public AudioClip[] destroySounds;
    

    public float pitchChange;
    public float volume;


    public void Start()
    {
        source = GetComponent<AudioSource>();

        scoreManager = ScoreManager.instance;        
    }

    public void BuildSoundPlay()
    {
        source.clip = buildSounds[Random.Range(0, buildSounds.Length)];
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange);
        source.volume = volume;

        source.PlayOneShot(source.clip);
    }

    public void DestroySoundPlay()
    {
        source.clip = destroySounds[Random.Range(0, destroySounds.Length)];
        source.pitch = Random.Range(1- pitchChange, 1+ pitchChange);
        source.volume = volume;

        source.PlayOneShot(source.clip);
    }    
}
