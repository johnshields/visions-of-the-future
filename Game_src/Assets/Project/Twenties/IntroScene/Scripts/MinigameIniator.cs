using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameIniator : MonoBehaviour
{   

    GuideAudio guideAudio;

    public void Start()
    {
        guideAudio = GuideAudio.instance;

    }

    public GameObject miniGameUI;
    public GameObject returnUI;
    public GameObject textUI;


    private int counter;

    private bool nextLevel;
    private bool previousLevel;

    public void Update()
    {
        NextLevelInput();
        PreviousLevelInput();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TextUI") && counter < 1)
        {
            textUI.SetActive(true);
            guideAudio.PlayTextSpeech();
            StartCoroutine(DestroyTextUI());
            counter ++;
        }

        else if (other.CompareTag("MiniGameUI"))
        {
            if (textUI.activeInHierarchy)
            {
                return;
            }

            else
            {
                miniGameUI.SetActive(true);
                guideAudio.PlayMiniGameSpeech();
                nextLevel = true;
            }
            
        }
        
        else if (other.CompareTag("ReturnUI"))
        {
            if (textUI.activeInHierarchy)
            {
                return;
            }

            else
            {
                returnUI.SetActive(true);                
                guideAudio.PlayReturnMenuSpeech();
                previousLevel = true;
            }
        }         
    }

    public void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("MiniGameUI"))
        {
            miniGameUI.SetActive(false);
        }

        else if (other.CompareTag("ReturnUI"))
        {
            returnUI.SetActive(false);
        }
    }

    public IEnumerator DestroyTextUI()
    {
        yield return new WaitForSecondsRealtime(5f);
        textUI.SetActive(false);
    }

    
    
    public void NextLevelInput()
    {
        if (nextLevel)
        {
            if (Input.GetKey(KeyCode.G))
            {
                nextLevel = false;
                SceneManager.LoadScene("1920s_TestBox", LoadSceneMode.Single);
            }
        }
    }

    public void PreviousLevelInput()
    {
        if (previousLevel)
        {
            if (Input.GetKey(KeyCode.G))
            {
                previousLevel = false;
                Debug.Log("Moved to previous Level");
            }
        }
    }
}
