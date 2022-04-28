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

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (waitTime < 0f)
            {
                source.clip = sounds[Random.Range(0, sounds.Length)];
                source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
                source.PlayOneShot(source.clip);
                waitTime = Random.Range(5, 12);
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
