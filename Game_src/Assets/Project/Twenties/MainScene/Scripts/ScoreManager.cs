using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{  
    public GameObject gameWonUI; // creates a gameobject that can be assigned in the inspector
    public GameObject shopUI;
    public GameObject _nodeUI;

    // Singleton pattern

    public static ScoreManager instance;

    public void Awake()
    {
        instance = this;
    }


    public TextMeshProUGUI scoreText; // creates a TextMeshPro text that can be assigned in the inspector

    public int scoreAmount;
        

    public void Update()
    {
        scoreText.text = scoreAmount.ToString(); // the score text displayed on the screen is equal to the score amount
        GameWonChecker(); // calls the GameWonChecker method
    }

    public void AddScore() // adds 5 points to score amount
    {
       scoreAmount += 5;       
    }
 
    public void DecreaseScore() // takes 5 points away from the score amount
    {
        scoreAmount -= 5;
    }

    public void GameWonChecker() // checks whether the max score has been reached yet
    {
        if (scoreAmount < 105) // if the score is less than 105
        { 
            return; // do nothing
        }

        else if (scoreAmount >= 105) // if the score is larger or equal to 105
        {
            gameWonUI.SetActive(true); // sets the gameWonUI to active
            shopUI.SetActive(false); // deactivates the shopUI, making the player unable to continue with the game once the max score has been reached
            _nodeUI.SetActive(false); // deactivates the _nodeUI, making the player unable to continue with the game once the max score has been reached
        }       
    }
}

   

