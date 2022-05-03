using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * TypeWriter
 * Script for Dialogue UIs to give the impression of 'talking' for Guides and Robot Butler.
 * Adapted from https://youtu.be/1qbjmb_1hV4
 */
public static class DialogueTyper
{
    public static IEnumerator TypeDialogue(string ct, string ft, GameObject dt)
    {
        for (int i = 0; i <= ft.Length; i++)
        {
            ct = ft.Substring(0, i);
            dt.GetComponent<Text>().text = ct;
            yield return new WaitForSeconds(0.1f);
        }
    }
}