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

    public Animator animator;
    private int levelToLoad;

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
    }

    public void FadeToNextLevel() 
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToNavigation() 
    {
        animator.SetTrigger("ReplicantFade");
        SceneManager.LoadScene(0);
    }

    public void FadeToLevel(int levelIndex) 
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        sceneChangeText.gameObject.SetActive(false);
    }

    public void OnFadeCompelte()
    {
        Debug.Log("OnFadeComplete Called");
        SceneManager.LoadScene(levelToLoad);
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
