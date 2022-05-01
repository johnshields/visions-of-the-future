using System.Collections;
using UnityEngine;

public class MrCircuits : MonoBehaviour
{
    private int _waveActive, _idleActive;
    private Animator _animator;

    public GameObject dialogueUI, dialogueText;
    private const string Ct = "";
    public string dialogueFt;

    private bool _complete;
    public AudioClip voice;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _idleActive = Animator.StringToHash("IdleActive");
        _waveActive = Animator.StringToHash("WaveActive");
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_complete)
        {
            // dialogue
            dialogueUI.SetActive(true);
            StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText));
            AudioSource.PlayClipAtPoint(voice, Camera.main!.transform.position, 0.2f);
            // animation
            _animator.SetTrigger(_waveActive);
            StartCoroutine(BackToIdle());
        }
        else print("Encounter completed...");
    }

    private IEnumerator BackToIdle()
    {
        _complete = true;
        yield return new WaitForSeconds(4.5f);
        _animator.SetBool(_idleActive, true);
        dialogueUI.SetActive(false);
    }
}