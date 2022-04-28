using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectDialogue : MonoBehaviour
{
    public GameObject dialogueUI, dialogueText;
    private const string Ct = "";
    public string dialogueFt;

    public Collider playerCollider;
    public bool isRunning = false;

    public AudioClip[] sounds;
    public AudioSource source;

    private void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player1980") && isRunning != true)
        {
            DroneAudio();
            dialogueUI.SetActive(true);
            StartCoroutine(AnimateDialogue(Ct, dialogueFt, dialogueText));
        }
        else {
            return;
        }
    }

    private void OnTriggerExit(Collider playerCollider)
    {
        dialogueUI.SetActive(false);    
        StopCoroutine(AnimateDialogue(Ct, dialogueFt, dialogueText));
    }

    public IEnumerator AnimateDialogue(string ct, string ft, GameObject dt)
    {
        Debug.Log("Animation Started");
        if (isRunning == false) {
            isRunning = true;
            for (int i = 0; i <= ft.Length; i++)
            {
                ct = ft.Substring(0, i);
                dt.GetComponent<TMP_Text>().text = ct;
                yield return new WaitForSeconds(0.05f);
            }
            isRunning = false;
        }
    }

    private void DroneAudio()
    {
        if (!source.isPlaying)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
        }
    }
}
