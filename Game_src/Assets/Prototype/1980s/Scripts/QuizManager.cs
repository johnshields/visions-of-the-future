using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public QuestionBluePrint[] questions;
    private static List<QuestionBluePrint> unansweredQuestions;

    private QuestionBluePrint currentQuestion;

    private static float currentScore = 0;

    [SerializeField] private TMP_Text factText;
    [SerializeField] private TMP_Text trueAnswerText;
    [SerializeField] private TMP_Text falseAnswerText;
    [SerializeField] private float questiondelay = 1.0f;

    [SerializeField] private Animator animator;

    public GameObject QuizPanel;
    public GameObject EndScreen;
    public GameObject ReplicantScreen;
    public GameObject HumanScreen;

    public Animator DroneAnimator;
    public Animator CanvasAnimator;

    void Start()
    {
        //If Unanswered Questions list is null (not empty) fills list
        if (unansweredQuestions == null) {
            unansweredQuestions = questions.ToList<QuestionBluePrint>();
        }
        
        //When unanswered Questions list becomes empty calls interview compelte function, else call set random question function
        if (unansweredQuestions.Count == 0) {
            InterviewComplete();
        }
        else {
            SetRandomQuestion();
            Debug.Log("Question: " + currentQuestion.text);
        }
    }

    void SetRandomQuestion() 
    {
        //Generates random number between 0 and remaining unanswered questions and sets current question to the chosen place in the list
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.text;

        //Changes text response under buttons based on user response
        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "Hmm...";
            falseAnswerText.text = "Interesting...";
        }
        else {
            trueAnswerText.text = "Interesting...";
            falseAnswerText.text = "Hmm...";
        }
    }

    IEnumerator TransitionToNextQuestion() 
    {
        //Removes Current question from the list
        unansweredQuestions.Remove(currentQuestion);

        //Waits for question delay to end
        yield return new WaitForSeconds(questiondelay);

        Debug.Log("Score: " + currentScore);
        Start();
    }

    //When user selects trueButton run checks and update necessary variables based on question/answer and starts coroutine for next question
    public void UserSelectTrue() {
        animator.SetTrigger("True");
        
        if (currentQuestion.isTrue) {
            Debug.Log("Correct Button Pushed");
            currentScore += 1;
        }
        else {
            Debug.Log("Incorrect Button Pushed");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    //When user selects falseButton run checks and update necessary variables based on question/answer and starts coroutine for next question
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");

        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct Button Pushed");
            currentScore += 1;
        }
        else
        {
            Debug.Log("Incorrect Button Pushed");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    //When interview is completed show/hide UI elements and triggers scene ending depending on user results
    void InterviewComplete() 
    {
        Debug.Log("All Questions Answered");
        Debug.Log("Final Score: " + currentScore);

        EndScreen.gameObject.SetActive(true);
        QuizPanel.gameObject.SetActive(false);

        if (currentScore >= 6) {
            //If user answered like a human, set Human animation for both the Drone Guide and Transition Canvas
            HumanScreen.gameObject.SetActive(true);
            DroneAnimator.SetTrigger("Human");
            CanvasAnimator.SetTrigger("HumanFade");
        }
        else if (currentScore <= 5) {
            //If user answered like a replicant, set Replicant animation for both Drone Guide and Transition Canvas
            ReplicantScreen.gameObject.SetActive(true);
            DroneAnimator.SetTrigger("Replicant");
            CanvasAnimator.SetTrigger("ReplicantFade");
        }
    }
}
