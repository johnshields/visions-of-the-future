using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInitiator : MonoBehaviour
{
    public GameObject twentiesPopUp, fiftiesPopUp, eightiesPopUp;
    private bool startTwentiesLevel, startFiftiesLevel, startEightiesLevel;

    public void Update()
    {
        StartSelectedLevel();
    }

    public void OnTriggerEnter(Collider other)
    {
        ActivePortal(other, true, true);
    }

    public void OnTriggerExit(Collider other)
    {
        ActivePortal(other, false, false);
    }

    private void ActivePortal(Component other, bool popup, bool level)
    {
        if (other.CompareTag($"1920sCollider"))
        {
            twentiesPopUp.SetActive(popup);
            startTwentiesLevel = level;
        }
        else if (other.CompareTag($"1950sCollider"))
        {
            fiftiesPopUp.SetActive(popup);
            startFiftiesLevel = level;
        }
        else if (other.CompareTag($"1980sCollider"))
        {
            eightiesPopUp.SetActive(popup);
            startEightiesLevel = level;
        }
    }

    private void StartSelectedLevel()
    {
        if (startTwentiesLevel && Input.GetKey(KeyCode.G))
        {
            startTwentiesLevel = false;
            Fader.CallFader(false, true);
            NavHubAudio.FadeMusic(false, true);
            StartCoroutine(LoadLevel("03_TwentiesOpeningScene"));
        }
        else if (startFiftiesLevel && Input.GetKey(KeyCode.G))
        {
            startFiftiesLevel = false;
            Fader.CallFader(false, true);
            NavHubAudio.FadeMusic(false, true);
            StartCoroutine(LoadLevel("05_RetrofuturismLevel"));
        }
        else if (startEightiesLevel && Input.GetKey(KeyCode.G))
        {
            startEightiesLevel = false;
            Fader.CallFader(false, true);
            NavHubAudio.FadeMusic(false, true);
            StartCoroutine(LoadLevel("1980_Intro")); // TODO - Update to main project.
        }
    }

    private IEnumerator LoadLevel(string levelName)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}