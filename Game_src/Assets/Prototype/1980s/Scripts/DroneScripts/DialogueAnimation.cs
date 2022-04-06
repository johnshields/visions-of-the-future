using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueAnimation : MonoBehaviour
{
    //public static bool isRunning;

    public static IEnumerator AnimateDialogue(string ct, string ft, GameObject dt) 
    {
        Debug.Log("Animation Started");
        //if (isRunning == false) {
            for (int i = 0; i <= ft.Length; i++)
            {
                //isRunning = true;
                ct = ft.Substring(0, i);
                dt.GetComponent<TMP_Text>().text = ct;
                yield return new WaitForSeconds(0.05f);
            }
            //isRunning = false;
        //}
    }
}
