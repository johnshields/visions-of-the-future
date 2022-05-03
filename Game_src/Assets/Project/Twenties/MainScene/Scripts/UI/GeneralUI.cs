using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralUI : MonoBehaviour
{
     

    
    public GameObject shopUI; // creates a game object that can be assigned in the inspector
    public GameObject transportZoneHintUI;
    public GameObject cultureZoneHintUI;
    public GameObject residentialZoneHintUI;
    public GameObject openingUI;
    public GameObject steppedZoneHintUI;

    public void Start()
    {
        StartCoroutine(OpeningUIActive()); // starts the OpeningUIActive coroutine
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("03_TwentiesOpeningScene", LoadSceneMode.Single); // loads 03_TwentiesOpeningScene
    }

    public void LoadNavHub()
    {
        SceneManager.LoadScene("02_NavHub", LoadSceneMode.Single); // loads 02_NavHub
    }

    public void HideTransportHint()
    {
        transportZoneHintUI.SetActive(false); // sets transportZoneHintUI to inactive
        shopUI.SetActive(true);  // sets shopUI to active
    }

    public void HideCultureHint() // same as above
    {
        cultureZoneHintUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public void HideSteppedHint() // same as above
    {
        steppedZoneHintUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public void HideResidentialHint() // same as above
    {
        residentialZoneHintUI.SetActive(false);
        shopUI.SetActive(true);
    }    

    public void HideOpeningUI() // same as above
    {
        openingUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public IEnumerator OpeningUIActive()
    {
        yield return new WaitForSecondsRealtime(2f); // waits for 2 seconds to execute below command
        openingUI.SetActive(true); // sets openingUI to active
    }
}
