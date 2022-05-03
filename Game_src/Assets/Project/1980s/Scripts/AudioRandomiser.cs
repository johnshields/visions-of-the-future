using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomiser : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;

    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplier = 0.2f;

    private float waitTime;

    void Start()
    {
        //Assigns source variable with chosen audio source
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        //When source is not playing audio, function will wait the alloted wait time
        if (!source.isPlaying)
        {
            if (waitTime < 0f)
            {
                //Selects random audio source and sets audio to randomised value to reduce repitition
                source.clip = sounds[Random.Range(0, sounds.Length)];
                source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
                //Plays audio clip all the way through without getting interrupted by other sources
                source.PlayOneShot(source.clip);

                //Wait time is randomised between 5 and 10 seconds, to stop audio from being too repetitive
                waitTime = Random.Range(15, 25);
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
