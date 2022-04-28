using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource[] sourceClip;
    private void OnTriggerEnter(Collider other)
    {
        sourceClip[0].Play();
        sourceClip[1].Play();
    }
}
