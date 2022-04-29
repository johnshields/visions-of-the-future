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
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToIntro()
    {
        animator.SetTrigger("HumanFade");
        SceneManager.LoadScene(1);
    }

    public void BackToNavigation()
    {
        animator.SetTrigger("ReplicantFade");
        SceneManager.LoadScene(0);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        //animator.SetTrigger("HumanFade");
        sceneChangeText.gameObject.SetActive(false);
    }

    public void OnFadeCompelte()
    {
        Debug.Log("OnFadeComplete Called");
        SceneManager.LoadScene(levelToLoad);
    }

    public void PlayGunshot() 
    {
        source = GetComponent<AudioSource>();
        reticle.gameObject.SetActive(false);
        StopAllAudio();
        source.PlayOneShot(source.clip);
    }

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioStop in allAudioSources)
        {
            audioStop.Stop();
        }
        return;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collider Entered");
        sceneChangeText.gameObject.SetActive(true);

        fadeOut = !fadeOut;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collier Exit");
        sceneChangeText.gameObject.SetActive(false);

        fadeOut = !fadeOut;
    }
}
