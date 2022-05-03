using UnityEngine;

/*
 * AudioPlayer
 * Script to Play Audio for Interactive Objects (1950's level).
 */
public class AudioPlayer : MonoBehaviour
{
    public AudioSource[] sourceClip;
    
    private void OnTriggerEnter(Collider other)
    {
        sourceClip[0].Play();
        sourceClip[1].Play();
        sourceClip[2].Play();
    }
}
