using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameIniator : MonoBehaviour
{ 

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
                previousLevel = true;
            }
        }         
    }

    public void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("MiniGameUI"))
        {
            miniGameUI.SetActive(false);
            nextLevel = false;
        }

        else if (other.CompareTag("ReturnUI"))
        {
            returnUI.SetActive(false);
            previousLevel = false;
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
                SceneManager.LoadScene("04_TwentiesCityBuilder", LoadSceneMode.Single);
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
                SceneManager.LoadScene("02_NavHub", LoadSceneMode.Single);
            }
        }
    }
}
