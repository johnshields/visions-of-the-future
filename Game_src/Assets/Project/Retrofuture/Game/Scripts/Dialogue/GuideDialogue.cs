using System.Collections;
using Building;
using UnityEngine;

namespace Guide
{
    public class GuideDialogue : MonoBehaviour
    {
        public GameObject dialogueUI, dialogueText;
        public string dialogueFt;
        private const string Ct = "";
        private bool _alreadySaid;

        private void Start()
        {
            dialogueFt = "What a day!";
            dialogueUI.SetActive(true);
            StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText));
            StartCoroutine(CloseDialogue());
        }

        private void Update()
        {
            if (BuildModeTrigger.build && !_alreadySaid)
            {
                LetsBuild();
                _alreadySaid = true;
            }
        }

        private void LetsBuild()
        {
            dialogueFt = "Lets build!";
            dialogueUI.SetActive(true);
            StartCoroutine(DialogueTyper.TypeDialogue(Ct, dialogueFt, dialogueText));
            StartCoroutine(CloseDialogue());
        }

        private IEnumerator CloseDialogue()
        {
            yield return new WaitForSeconds(3.5f);
            dialogueUI.SetActive(false);
        }
    }
}