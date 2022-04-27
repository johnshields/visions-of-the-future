using System.Collections;
using UnityEngine;

public class GuideDialogue : MonoBehaviour
{
    public GameObject dialogueUI, dialogueText;
    public string dialogueFt;
    private const string Ct = "";

    private void Start()
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