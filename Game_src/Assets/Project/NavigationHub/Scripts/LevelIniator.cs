using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIniator : MonoBehaviour
{
    public GameObject twentiesPopUp;
    public GameObject fiftiesPopUp;
    public GameObject eightiesPopUp;

    private bool startTwentiesLevel;
    private bool startFiftiesLevel;
    private bool startEightiesLevel;

    public void Update()
    {
        StartTwentiesLevel();
        StartFiftiesLevel();
        StartEightiesLevel();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("1920sCollider"))
        {
            twentiesPopUp.SetActive(true);
            startTwentiesLevel = true;
        }

        else if (other.CompareTag("1950sCollider"))
        {
            fiftiesPopUp.SetActive(true);
            startFiftiesLevel = true;
        }

        else if (other.CompareTag("1980sCollider"))
        {
            eightiesPopUp.SetActive(true);
            startEightiesLevel = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("1920sCollider"))
        {
            twentiesPopUp.SetActive(false);
            startTwentiesLevel = false;
        }

        else if (other.CompareTag("1950sCollider"))
        {
            fiftiesPopUp.SetActive(false);
            startFiftiesLevel = false;
        }

        else if (other.CompareTag("1980sCollider"))
        {
            eightiesPopUp.SetActive(false);
            startEightiesLevel = false;
        }
    }

    public void StartTwentiesLevel()
    {
        if (startTwentiesLevel)
        {
            if (Input.GetKey(KeyCode.G))
            {
                startTwentiesLevel = false;
                SceneManager.LoadScene("03_TwentiesOpeningScene", LoadSceneMode.Single);
            }
        }
    }

    public void StartFiftiesLevel()
    {
        if (startFiftiesLevel)
        {
            if (Input.GetKey(KeyCode.G))
            {
                startFiftiesLevel = false;
                Debug.Log("1950s");
            }
        }
    }

    public void StartEightiesLevel()
    {
        if (startEightiesLevel)
        {
            if (Input.GetKey(KeyCode.G))
            {
                startEightiesLevel = false;
                Debug.Log("1980s");
            }
        }
    }

}
