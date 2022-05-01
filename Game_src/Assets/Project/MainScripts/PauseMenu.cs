using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _paused;
    public GameObject menu;

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
        //Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        // Resume - volume & time.
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        _paused = false;
        menu.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
        _paused = false;
    }
}