using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueAnimation : MonoBehaviour
{
    //Simple coroutine to animate dialogue that can be called from any other script. Takes in the empty string, the dialogue line, and Game Object
    public static IEnumerator AnimateDialogue(string ct, string ft, GameObject dt) 
    {
        Debug.Log("Animation Started");
        //Runs through each leter of the given string and displays in in the chosen text box. Then waits 0.03 seconds before moving to next letter for typing effect
        for (int i = 0; i <= ft.Length; i++) 
        {
            ct = ft.Substring(0, i);
            dt.GetComponent<TMP_Text>().text = ct;
            yield return new WaitForSeconds(0.03f);
        }

    }
}
