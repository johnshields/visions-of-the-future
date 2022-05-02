using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralUI : MonoBehaviour
{
     

    
    public GameObject shopUI;
    public GameObject transportZoneHintUI;
    public GameObject cultureZoneHintUI;
    public GameObject residentialZoneHintUI;
    public GameObject openingUI;

    public int transportHintCounter;
    public int cultureHintCounter;
    public int residentialHintCounter;

    public void Start()
    {
        StartCoroutine(OpeningUIActive());
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("1920s_IntroScene", LoadSceneMode.Single);
        Debug.Log("Intro scene has been loaded");
    }

    public void LoadNavHub()
    {
        Debug.Log("NavHub scene has been loaded");
    }

    public void HideTransportHint()
    {
        transportZoneHintUI.SetActive(false);
        shopUI.SetActive(true);                
    }

    public void HideCultureHint()
    {
        cultureZoneHintUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public void HideResidentialHint()
    {
        residentialZoneHintUI.SetActive(false);
        shopUI.SetActive(true);
    }    

    public void HideOpeningUI()
    {
        openingUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public IEnumerator OpeningUIActive()
    {
        yield return new WaitForSecondsRealtime(2f);
        openingUI.SetActive(true);
    }
}
