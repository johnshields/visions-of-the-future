using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static bool _paused;
    public GameObject menu;
    public GameObject levelBanner;
    public string currentLevel;

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
        SceneManager.LoadScene("NavigationHub");
        _paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
        _paused = false;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    private void OnGUI()
    {
        var bannerText = levelBanner.GetComponent<Text>();
        bannerText.text = currentLevel;
    }
}