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
        SceneManager.LoadScene("03_TwentiesOpeningScene", LoadSceneMode.Single);
    }

    public void LoadNavHub()
    {
        SceneManager.LoadScene("02_NavHub", LoadSceneMode.Single);
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
