using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * PauseMenu
 * Script for controlling the interaction (Buttons) of the PauseMenu.
 */
namespace Main
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool _paused;
        public GameObject menu, levelBanner, uiClicks;
        public string currentLevel;
        private int _input;

        private void Start()
        {
            menu.SetActive(false);
        }

        private void Update()
        {
            // if esc pressed pause game else resume.
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (_paused) ResumeGame();
            else PauseGame();
        }

        private void PauseGame()
        {
            // Pause - volume & time.
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
            _paused = true;
            menu.SetActive(true);
        }

        public void ResumeGame()
        {
            // To change input sound.
            uiClicks.GetComponent<UIClicks>().input = 2;
            // Resume - volume & time.
            Time.timeScale = 1f;
            AudioManager.MuteActive();
            _paused = false;
            menu.SetActive(false);
        }

        public void NavHub()
        {
            uiClicks.GetComponent<UIClicks>().input = 1;
            ResetTimeAndAudio();
            _input = 0;
            _paused = false;
            menu.SetActive(false);
            // Fade the scene and call do next to load NavHub.
            Fader.CallFader(false, true);
            StartCoroutine(DoNext(2f));
        }

        public void MainMenu()
        {
            uiClicks.GetComponent<UIClicks>().input = 1;
            ResetTimeAndAudio();
            _input = 1;
            _paused = false;
            menu.SetActive(false);
            // Fade the scene and call do next to load MainMenu.
            Fader.CallFader(false, true);
            StartCoroutine(DoNext(2f));
        }

        public void ExitSound()
        {
            uiClicks.GetComponent<UIClicks>().input = 3;
            ResetTimeAndAudio();
        }

        public void ExitGame()
        {
            ResetTimeAndAudio();
            _input = 2;
            _paused = false;
            menu.SetActive(false);
            Fader.CallFader(false, true);
            StartCoroutine(DoNext(2f));
        }

        // For loading the NavHub, MainMenu and Exiting the game.
        private IEnumerator DoNext(float time)
        {
            yield return new WaitForSeconds(time);
            if (_input == 0)
                SceneManager.LoadScene("02_NavHub");
            else if (_input == 1)
                SceneManager.LoadScene("01_MainMenu");
            else if (_input == 2)
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

        // Update the text on UI to current level set in Inspector.
        private void OnGUI()
        {
            var bannerText = levelBanner.GetComponent<Text>();
            bannerText.text = currentLevel;
        }
        
        private void ResetTimeAndAudio()
        {
            Time.timeScale = 1f;
            AudioManager.MuteActive();
        }
    }
}