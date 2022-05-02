using UnityEngine;

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
        if (other.CompareTag($"1920sCollider"))
        {
            Debug.Log("collision");
            twentiesPopUp.SetActive(true);
            startTwentiesLevel = true;
        }
        else if (other.CompareTag($"1950sCollider"))
        {
            fiftiesPopUp.SetActive(true);
            startFiftiesLevel = true;
        }
        else if (other.CompareTag($"1980sCollider"))
        {
            eightiesPopUp.SetActive(true);
            startEightiesLevel = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag($"1920sCollider"))
            twentiesPopUp.SetActive(false);
        else if (other.CompareTag($"1950sCollider"))
            fiftiesPopUp.SetActive(false);
        else if (other.CompareTag($"1980sCollider"))
            eightiesPopUp.SetActive(false);
    }

    private void StartSelectedLevel()
    {
        if (startTwentiesLevel && Input.GetKey(KeyCode.G))
        {
            startTwentiesLevel = false;
            NavHubAudio.FadeMusic(false, true);
            Fader.CallFader(false, true);
            Debug.Log("1920s");
        }
        else if (startFiftiesLevel && Input.GetKey(KeyCode.G))
        {
            startFiftiesLevel = false;
            NavHubAudio.FadeMusic(false, true);
            Fader.CallFader(false, true);
            Debug.Log("1950s");
        }
        else if (startEightiesLevel && Input.GetKey(KeyCode.G))
        {
            startEightiesLevel = false;
            NavHubAudio.FadeMusic(false, true);
            Fader.CallFader(false, true);
            Debug.Log("1980s");
        }
    }
}