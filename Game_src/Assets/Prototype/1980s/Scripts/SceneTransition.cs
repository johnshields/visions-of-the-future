using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public TMP_Text sceneChangeText;
    public bool fadeOut = false;
    public bool replicantFade = false;
    public bool humanFade = false;

    public Animator animator;
    private int levelToLoad;

    public AudioSource source;
    public GameObject reticle;

    private AudioSource[] allAudioSources;


    // Update is called once per frame
    void Update()
    {
        //Calls required function when change is made or input is given
        if (fadeOut)
        {
            if (Input.GetKey("l"))
            {
                Debug.Log("Scene transition called");
                FadeToNextLevel();
            }
        }

        if (replicantFade) {
            Debug.Log("Replicant Scene Transition Called");
            BackToNavigation();
        }
        if (humanFade) {
            Debug.Log("Human Scene Transition Called");
            BackToIntro();
        }
    }

    public void FadeToNextLevel()
    {
        //Calls FadeToLevel function with the next scene in build index
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Sets HumanFade value for canvas and loads intro scene
    public void BackToIntro()
    {
        animator.SetTrigger("HumanFade");
        SceneManager.LoadScene(1);
    }

    //Sets ReplicantFade value for canvas and restarts to navigation hub
    public void BackToNavigation()
    {
        animator.SetTrigger("ReplicantFade");
        SceneManager.LoadScene(0);
    }

    //Sets the level to load and removes the sceneChange text UI element
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        sceneChangeText.gameObject.SetActive(false);
    }

    //Gets called from canvas animation when fade transition is completed
    public void OnFadeCompelte()
    {
        Debug.Log("OnFadeComplete Called");
        SceneManager.LoadScene(levelToLoad);
    }

    //Plays Gundshot sound and removes all unecessary elements from canvas
    public void PlayGunshot() 
    {
        source = GetComponent<AudioSource>();
        reticle.gameObject.SetActive(false);

        //Stops all audio before playing gunshot sound
        StopAllAudio();
        source.PlayOneShot(source.clip);
    }

    //Runs through all audio sources in the scene and stops each one in turn
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioStop in allAudioSources)
        {
            audioStop.Stop();
        }
        return;
    }

    //Shows chosen UI element when collider is entered and switches fadeOut variable
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collider Entered");
        sceneChangeText.gameObject.SetActive(true);

        fadeOut = !fadeOut;
    }

    //Hides chosen UI element when collider is exited and switches fadeOut variable
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collier Exit");
        sceneChangeText.gameObject.SetActive(false);

        fadeOut = !fadeOut;
    }
}
