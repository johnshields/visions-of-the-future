using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * MainMenu
 * Script for controlling the interaction (Buttons) of the MainMenu.
 */
namespace Main
{
    public class MainMenu : MonoBehaviour
    {
        private int _input;
        public GameObject menuMusic, uiClicks, tagline;

        private void Awake()
        {
            FadeMusic(true, false);
            Time.timeScale = 1f;
            AudioManager.MuteActive();
            
            // Only play tagline on initial startup.
            if (!TaglineBool.alreadyPlayed)
            { 
                StartCoroutine(Tagline());
                TaglineBool.alreadyPlayed = true;
            }
        }

        public void StartGame()
        {
            // To change input sound.
            uiClicks.GetComponent<UIClicks>().input = 1;
            _input = 0;
            // Fade Music, Scene and call Do Next to load NavHub.
            FadeMusic(false, true);
            Fader.CallFader(false, true);
            StartCoroutine(DoNext(2f));
        }

        public void Options()
        {
            uiClicks.GetComponent<UIClicks>().input = 2;
        }

        public void ExitSound()
        {
            uiClicks.GetComponent<UIClicks>().input = 3;
        }

        // Fade Audio and Scene, Then call DoNext to Exit the game.
        public void ExitGame()
        {
            _input = 1;
            FadeMusic(false, true);
            Fader.CallFader(false, true);
            StartCoroutine(DoNext(2f));
        }

        // Access the Menu music animator and fade it depending on the parameters.
        private void FadeMusic(bool fadeIn, bool fadeOut)
        {
            menuMusic.GetComponent<Animator>().SetBool("FadeIn", fadeIn);
            menuMusic.GetComponent<Animator>().SetBool("FadeOut", fadeOut);
        }

        // Play tagline after 1 second.
        private IEnumerator Tagline()
        {
            yield return new WaitForSeconds(1f);
            tagline.GetComponent<AudioSource>().Play();
        }

        // For loading the NavHub and Exiting the game.
        private IEnumerator DoNext(float time)
        {
            yield return new WaitForSeconds(time);
            if (_input == 0)
                SceneManager.LoadScene("02_NavHub");
            else if (_input == 1)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
           Application.Quit();
#endif
            }
            else
                print("Unable to do...");
        }
    }
}