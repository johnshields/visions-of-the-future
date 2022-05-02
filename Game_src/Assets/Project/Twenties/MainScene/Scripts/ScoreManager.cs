using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{  
    public GameObject gameWonUI;
    public GameObject shopUI;
    public GameObject _nodeUI;

    public static ScoreManager instance;

    public void Awake()
    {
        instance = this;
    }

    public TextMeshProUGUI scoreText;

    public int scoreAmount;
        

    public void Update()
    {
        scoreText.text = scoreAmount.ToString();
        GameWonChecker();
    }

    public void AddScore()
    {
       scoreAmount += 5;       
    }

    public void DecreaseScore()
    {
        scoreAmount -= 5;
        Debug.Log("points taken away");
    }

    public void GameWonChecker()
    {
        if (scoreAmount < 105)
        {
            return;
        }

        else if (scoreAmount >= 105)
        {
            gameWonUI.SetActive(true);
            shopUI.SetActive(false);
            _nodeUI.SetActive(false);
        }       
    }
}

   

