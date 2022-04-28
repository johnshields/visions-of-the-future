using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    public AudioClip[] uiSound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        //source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound() {
        source.clip = uiSound[Random.Range(0, uiSound.Length)];
        source.volume = 0.5f;
        source.PlayOneShot(source.clip);
    }
}
