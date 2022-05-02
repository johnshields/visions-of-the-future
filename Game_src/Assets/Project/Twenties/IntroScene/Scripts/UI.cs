using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public GameObject miniGameUI;
    public GameObject returnMenuUI;

    
    public void LoadNextScene()
    {
        
    }

    public void ExitMiniGamePopUp()
    {
        miniGameUI.SetActive(false);
    }

    public void LoadPreviousScene()
    {
        Debug.Log("Previous Scene loaded");
    }

    public void ExitReturnPopUp()
    {
        returnMenuUI.SetActive(false);
    }
}
