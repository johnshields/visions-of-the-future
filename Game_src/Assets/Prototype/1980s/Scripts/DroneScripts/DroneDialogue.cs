using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DroneDialogue : MonoBehaviour
{
    public GameObject dialogueUI, dialogueText;
    public string dialogueFt;
    private const string Ct = "";

    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(true);
        StartCoroutine(AnimateDialogue(Ct, dialogueFt, dialogueText));
        StartCoroutine(CloseDialogue());
    }

    private IEnumerator CloseDialogue() 
    {
        yield return new WaitForSeconds(3f);
        dialogueUI.SetActive(false);
    }

    public IEnumerator AnimateDialogue(string ct, string ft, GameObject dt)
    {
        Debug.Log("Animation Started");
        if (isRunning == false)
        {
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
}
