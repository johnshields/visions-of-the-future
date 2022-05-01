using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static bool _paused;
    public GameObject menu;
    public GameObject levelBanner;
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
        // Resume - volume & time.
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        _paused = false;
        menu.SetActive(false);
    }
    
    public void NavHub()
    {
        Time.timeScale = 1f;
        _input = 0;
        _paused = false;
        menu.SetActive(false);
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        _input = 1;
        _paused = false;
        menu.SetActive(false);
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }
    
    public void ExitGame()
    {
        Time.timeScale = 1f;
        _input = 2;
        _paused = false;
        menu.SetActive(false);
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }
    
    private IEnumerator DoNext(float time)
    {
        print(_input);
        yield return new WaitForSeconds(time);
        if (_input == 0)
        {
            SceneManager.LoadScene("NavigationHub");
        }
        
        else if (_input == 1)
        {
            SceneManager.LoadScene("01_MainMenu");
        }
        else if (_input == 2)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
           Application.Quit();
#endif
        }
        else
            print("no can do...");
    }
    
    private void OnGUI()
    {
        var bannerText = levelBanner.GetComponent<Text>();
        bannerText.text = currentLevel;
    }
}