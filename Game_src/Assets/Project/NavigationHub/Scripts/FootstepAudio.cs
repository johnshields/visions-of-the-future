using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioClip[] footSteps;

    public AudioSource source;

    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Footsteps()
    {
        source.clip = footSteps[Random.Range(0, footSteps.Length)];
        source.volume = volume;

        source.PlayOneShot(source.clip);
    }
}
