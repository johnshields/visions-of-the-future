using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _input;
    public GameObject menuMusic;

    public void Awake()
    {
        FadeMusic(true, false);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    public void StartGame()
    {
        _input = 0;
        FadeMusic(false, true);
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }

    public void ExitGame()
    {
        _input = 1;
        FadeMusic(false, true);
        Fader.CallFader(false, true);
        StartCoroutine(DoNext(2f));
    }

    private void FadeMusic(bool fadeIn, bool fadeOut)
    {
        menuMusic.GetComponent<Animator>().SetBool("FadeIn", fadeIn);
        menuMusic.GetComponent<Animator>().SetBool("FadeOut", fadeOut);
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