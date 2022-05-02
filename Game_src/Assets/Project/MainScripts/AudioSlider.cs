using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    private GameObject audioObject;
    private AudioSource audioSource;

    public Button audioButton;
    public Slider audioSlider;
    public Sprite audioNotch0;
    public Sprite audioNotch1;
    public Sprite audioNotch2;
    public Sprite audioNotch3;

    public GameObject sliderObject;

    void Start()
    {
        //Finds audio objects in scene and sets the audio source volume value to the slider value

        //audioObject = GameObject.FindGameObjectWithTag("Music");
        //audioSource = audioObject.GetComponent<AudioSource>();
        audioSlider.value = AudioListener.volume;
    }

    void Update()
    {
        if (audioSource != null)
        {
            AudioListener.volume = audioSlider.value;

            //Updates sprite image in line with current volume
            if (audioSource.volume <= 0.2)
            {
                audioButton.GetComponent<Image>().sprite = audioNotch0;
            }

            if (audioSource.volume <= 0.15)
            {
                audioButton.GetComponent<Image>().sprite = audioNotch1;
            }

            if (audioSource.volume <= 0.1)
            {
                audioButton.GetComponent<Image>().sprite = audioNotch2;
            }

            if (audioSource.volume <= 0)
            {
                audioButton.GetComponent<Image>().sprite = audioNotch3;
            }
        }
    }

    public void ToggleSlider()
    {
        if (sliderObject.activeInHierarchy)
        {
            sliderObject.SetActive(false);
        }
        else
        {
            sliderObject.SetActive(true);
        }
    }

}
