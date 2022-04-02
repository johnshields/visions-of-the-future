using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDialogue : MonoBehaviour
{
    public GameObject dialogueUI, dialogueText;
    public string dialogueFt;
    private const string Ct = "";

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(true);
        StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText));
        StartCoroutine(CloseDialogue());
    }

    private IEnumerator CloseDialogue() 
    {
        yield return new WaitForSeconds(3f);
        dialogueUI.SetActive(false);
    }
}
