using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script can only be placed on Button objects
[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    public AudioClip[] uiSound;

    //Gets and sets chosen button and audio source components and stores in private variables
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        //Assigns chosen audio source
        gameObject.AddComponent<AudioSource>();

        //Adds listener so that audio is played when button object is clicked
        button.onClick.AddListener(() => PlaySound());
    }

    //Plays randomised sound clip from array and sets volume
    void PlaySound() {
        source.clip = uiSound[Random.Range(0, uiSound.Length)];
        source.volume = 0.5f;
        source.PlayOneShot(source.clip);
    }
}
