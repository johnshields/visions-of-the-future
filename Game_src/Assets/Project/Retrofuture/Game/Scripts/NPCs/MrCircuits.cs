using System.Collections;
using UnityEngine;

/*
 * MrCircuits
 * Script to control MrCircuits (Robot Butler) Interactions (Animation & Dialogue)
 */
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
            // Activate dialogue & animation.
            dialogueUI.SetActive(true);
            // Call DialogueTyper to type out what MrCircuits says.
            StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText));
            // MrCircuits voice audio.
            AudioSource.PlayClipAtPoint(voice, Camera.main!.transform.position, 0.2f);
            // Trigger animation.
            _animator.SetTrigger(_waveActive);
            StartCoroutine(BackToIdle());
        }
        else print("Encounter completed...");
    }

    // Set MrCircuits back to Idle.
    private IEnumerator BackToIdle()
    {
        _complete = true;
        yield return new WaitForSeconds(4.5f);
        _animator.SetBool(_idleActive, true);
        dialogueUI.SetActive(false);
    }
}