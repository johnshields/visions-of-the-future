using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

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

    private static IEnumerator LoadScene()
    {
        Fader.CallFader(false, true);
        yield return new WaitForSeconds(2f);
        _gameOverUI.SetActive(true);
        _videoPlayer.GetComponent<VideoPlayer>().Prepare();
        while (_videoPlayer.GetComponent<VideoPlayer>().isPrepared)
        {
            yield return new WaitForSeconds(0.1f);
            break;
        }
        print("video play");
        _videoPlayer.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(8f);
        Fader.CallFader(false, true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("NavigationHub");
    }
}
