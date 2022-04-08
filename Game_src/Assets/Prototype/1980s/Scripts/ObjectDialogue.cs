using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDialogue : MonoBehaviour
{
    public GameObject dialogueUI, dialogueText;
    private const string Ct = "";
    public string dialogueFt;

    public Collider playerCollider;

    private void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player1980"))
        {
            dialogueUI.SetActive(true);
            StartCoroutine(DialogueAnimation.AnimateDialogue(Ct, dialogueFt, dialogueText));
        }
        else {
            return;
        }
    }

    private void OnTriggerExit(Collider playerCollider)
    {
        dialogueUI.SetActive(false);    
        StopCoroutine(DialogueAnimation.AnimateDialogue(Ct, dialogueFt, dialogueText));
    }
}

//OnMouseDown function instead, that also highlights the object and launches the dialogue animation
//
