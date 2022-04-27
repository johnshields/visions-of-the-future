using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueAnimation : MonoBehaviour
{
    public static IEnumerator AnimateDialogue(string ct, string ft, GameObject dt) 
    {
        Debug.Log("Animation Started");
            for (int i = 0; i <= ft.Length; i++)
            {
                ct = ft.Substring(0, i);
                dt.GetComponent<TMP_Text>().text = ct;
                yield return new WaitForSeconds(0.03f);
            }

    }
}
