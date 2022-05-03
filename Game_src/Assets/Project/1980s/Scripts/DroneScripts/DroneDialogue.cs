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

    [SerializeField]
    public float waitTime;

    void Start()
    {
        //Shows dialogue UI and begins animated text coroutine
        dialogueUI.SetActive(true);
        StartCoroutine(AnimateDialogue(Ct, dialogueFt, dialogueText));
        StartCoroutine(CloseDialogue());
    }

    //Called to close the Drone Dialogue after chosen amount of time.
    private IEnumerator CloseDialogue() 
    {
        yield return new WaitForSeconds(waitTime);
        dialogueUI.SetActive(false);
    }

    //Taken from Dialogue Animation Script
    public IEnumerator AnimateDialogue(string ct, string ft, GameObject dt)
    {
        Debug.Log("Animation Started");
        //Only runs once previous dialogue is complete
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
