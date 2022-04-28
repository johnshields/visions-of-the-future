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
        if (unansweredQuestions == null) {
            unansweredQuestions = questions.ToList<QuestionBluePrint>();
        }
        
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
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.text;

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
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(questiondelay);

        Debug.Log("Score: " + currentScore);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Start();
    }

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

    void InterviewComplete() 
    {
        Debug.Log("All Questions Answered");
        Debug.Log("Final Score: " + currentScore);

        EndScreen.gameObject.SetActive(true);
        QuizPanel.gameObject.SetActive(false);

        if (currentScore >= 6) {
            HumanScreen.gameObject.SetActive(true);
        }
        else if (currentScore <= 5) {
            ReplicantScreen.gameObject.SetActive(true);
            DroneAnimator.SetTrigger("Replicant");
            CanvasAnimator.SetTrigger("ReplicantFade");
        }
    }
}
