using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralUI : MonoBehaviour
{
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("1920s_IntroScene", LoadSceneMode.Single);
        Debug.Log("Intro scene has been loaded");
    }
}
