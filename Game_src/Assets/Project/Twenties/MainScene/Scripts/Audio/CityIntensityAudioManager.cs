using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityIntensityAudioManager : MonoBehaviour
{

    public static CityIntensityAudioManager instance;

    public void Awake()
    {
        instance = this;
    }



    ScoreManager scoreManager;
    

    public GameObject intensityLayer1;
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

        intensityAudio1 = intensityLayer1.GetComponent<AudioSource>();
        intensityAudio2 = intensityLayer2.GetComponent<AudioSource>();
        intensityAudio3 = intensityLayer3.GetComponent<AudioSource>();

        layer1 = null;
        layer2 = null;
        layer3 = null;
    }

    public void CityIntensityIncreaser()
    {
        if (scoreManager.scoreAmount < 5)
        {
            return;
        }

        else if (scoreManager.scoreAmount >= 5 && scoreManager.scoreAmount < 20 && layer1 == null)
        {            
            intensityAudio1.Play();
            layer1 = intensityAudio1;         
            
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

    public void CityIntensityDecreaser()
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
