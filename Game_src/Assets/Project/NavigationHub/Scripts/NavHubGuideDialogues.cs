using System.Collections;
using UnityEngine;

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

    public void Talk(string p, int gm)
    {
        _audioSource.PlayOneShot(voiceClips[gm]);
        PhraseChanger(p, gm);
        dialogueUI[gm].SetActive(true);
    }

    private void PhraseChanger(string phrase, int guideNum)
    {
        dialogueFt = phrase;
        StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText[guideNum]));
    }

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
