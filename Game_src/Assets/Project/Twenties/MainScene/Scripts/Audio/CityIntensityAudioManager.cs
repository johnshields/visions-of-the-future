using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityIntensityAudioManager : MonoBehaviour
{
    // singleton Pattern

    public static CityIntensityAudioManager instance;

    public void Awake()
    {
        instance = this;
    }



    ScoreManager scoreManager;
    

    public GameObject intensityLayer1; // creates a gameobject that can be assigned in the inspector
    public GameObject intensityLayer2;
    public GameObject intensityLayer3;

    private AudioSource intensityAudio1;
    private AudioSource intensityAudio2;
    private AudioSource intensityAudio3;


    private AudioSource layer1;
    private AudioSource layer2;
    private AudioSource layer3;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = ScoreManager.instance;

        intensityAudio1 = intensityLayer1.GetComponent<AudioSource>(); // gets the audiosource component of the gameobject assigned in the inspector
        intensityAudio2 = intensityLayer2.GetComponent<AudioSource>();
        intensityAudio3 = intensityLayer3.GetComponent<AudioSource>();

        layer1 = null; // sets layer1 to null
        layer2 = null;
        layer3 = null;
    }

    public void CityIntensityIncreaser() // increases the intensity of the ambient audio layers
    {
        if (scoreManager.scoreAmount < 5) // if the score amount is below 5
        {
            return; // do nothing
        }

        else if (scoreManager.scoreAmount >= 5 && scoreManager.scoreAmount < 20 && layer1 == null) // if the score amount is greater than 5, less than 20 and layer1 is equal to null
        {            
            intensityAudio1.Play(); // play intensityaudio1
            layer1 = intensityAudio1; // by setting layer 1 to intensityAudio1 then intesnityAudio1 will not get played again as it is already active
            
        }

        else if (scoreManager.scoreAmount >= 20 && scoreManager.scoreAmount < 60 && layer2 == null)
        {            
            intensityAudio2.Play();
            layer2 = intensityAudio2;
        }

        else if (scoreManager.scoreAmount >= 60 && layer3 == null)
        {
            intensityAudio3.Play();
            layer3 = intensityAudio3;
        }
    }

    public void CityIntensityDecreaser() // decreases the intensity of the ambient audio layers, same as above but in reverse
    {
        if (scoreManager.scoreAmount < 5)
        {
            intensityAudio1.Stop();
            layer1 = null;
        }

        else if (scoreManager.scoreAmount >= 5 && scoreManager.scoreAmount < 20)
        {            
            intensityAudio2.Stop();
            layer2 = null;
            
        }

        else if (scoreManager.scoreAmount >= 20 && scoreManager.scoreAmount < 60)
        {            
            intensityAudio3.Stop();
            layer3 = null;
        }

        else if (scoreManager.scoreAmount >= 60)
        {
            return;
        }
    }
}
