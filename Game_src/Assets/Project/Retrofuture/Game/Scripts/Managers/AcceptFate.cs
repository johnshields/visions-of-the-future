using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/*
 * AcceptFate
 * Script to End 1950's Level.
 */
public class AcceptFate : MonoBehaviour
{
    private static GameObject _videoPlayer;
    private static GameObject _gameOverUI;

    private void Awake()
    {
        _videoPlayer = GameObject.FindGameObjectWithTag("Video");
        _gameOverUI = GameObject.Find("HUD/GameOverScreen");
        _gameOverUI.SetActive(false);
    }

    public void CallGameOver()
    {
        StartCoroutine(LoadScene());
    }

    // IEnumerator to play ending video and Fade to NavHub. 
    private static IEnumerator LoadScene()
    {
        Fader.CallFader(false, true);
        yield return new WaitForSeconds(2f);
        _gameOverUI.SetActive(true);
        _videoPlayer.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(8f);
        Fader.CallFader(false, true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("02_NavHub");
    }
}
