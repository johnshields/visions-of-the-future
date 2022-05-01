using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _input;

    public void Awake()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    public void StartGame()
    {
        _input = 0;
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }

    public void ExitGame()
    {
        _input = 1;
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }

    private IEnumerator DoNext(float time)
    {
        yield return new WaitForSeconds(time);
        if (_input == 0)
            SceneManager.LoadScene("NavigationHub");
        else if (_input == 1)
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
}