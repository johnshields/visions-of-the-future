using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Blueprint for interrogation questions that takes in required fields
[System.Serializable]
public class QuestionBluePrint
{
    public string text;
    public int answer;

    public bool isTrue;
    public bool usUnanswered;
}
