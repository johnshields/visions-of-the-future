using System.Collections;
using UnityEngine;

/*
 * NavHubGuideDialogues
 * Script for controlling all 3 Guide Dialogue in NavHub.
 */
public class NavHubGuideDialogues : MonoBehaviour
{
    public GameObject[] dialogueUI, dialogueText, guides;
    public AudioClip[] voiceClips;
    private AudioSource _audioSource;
    public string dialogueFt;
    private const string Ct = "";

    private void Awake()
    {
        StartCoroutine(TalkNext());
        _audioSource = GetComponent<AudioSource>();
    }

    // For playing Audio and activate the Guide's Dialogue UI.
    public void Talk(string p, int gm)
    {
        _audioSource.PlayOneShot(voiceClips[gm]);
        PhraseChanger(p, gm);
        dialogueUI[gm].SetActive(true);
    }

    // For changing phrase depending on the Guide.
    private void PhraseChanger(string phrase, int guideNum)
    {
        dialogueFt = phrase;
        StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText[guideNum]));
    }

    // IEnumerator to play on Awake to make the Guides greet the player one after another.
    private IEnumerator TalkNext()
    {
        yield return new WaitForSeconds(2.5f);
        Talk("Salutations!", 0);
        yield return new WaitForSeconds(3.5f);
        dialogueUI[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        Talk("Hello!", 1);
        yield return new WaitForSeconds(2f);
        dialogueUI[1].SetActive(false);
        yield return new WaitForSeconds(1f);
        Talk("Hi!", 2);
        yield return new WaitForSeconds(2f);
        dialogueUI[2].SetActive(false);
    }
}
