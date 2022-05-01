using UnityEngine;

public class UIClicks : MonoBehaviour
{
    public AudioClip[] clickSound;
    public int input;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        switch (input)
        {
            case 1:
                _audioSource.PlayOneShot(clickSound[0]);
                input = 0;
                break;
            case 2:
                _audioSource.PlayOneShot(clickSound[1]);
                input = 0;
                break;
            case 3:
                _audioSource.PlayOneShot(clickSound[2]);
                input = 0;
                break;
        }
    }
}
