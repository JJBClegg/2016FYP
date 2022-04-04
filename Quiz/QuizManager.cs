using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour {

    //basic score
    public static int score;

    //question text displayed on the canvas
    private Text questionText;

    //the question number we are currently on
    private int questionNumber;

    //set up file paths to question and aswer folders
    private string questionFilePath;
    private string answerAFilePath;
    private string answerBFilePath;
    private string answerCFilePath;
    private string answerDFilePath;
    private string correctAnswerFilePath;

    //variable for the correct answer for current question
    string currentAnswer;

    //answer button texts (the text displayed on the buttons in-game)
    private Text answeButtonAText;
    private Text answeButtonBText;
    private Text answeButtonCText;
    private Text answeButtonDText;

    //variables to old the text files
    private TextAsset activeQuestion;
    private TextAsset activeAnswerA;
    private TextAsset activeAnswerB;
    private TextAsset activeAnswerC;
    private TextAsset activeAnswerD;
    private TextAsset activeCurrentAnswer;

    //the UI component on which all buttons, text and images are displayed
    private GameObject canvas;

    //question object
    private GameObject question;

    //a list to hold all answer buttons
    private List<GameObject> answerButtons = new List<GameObject>();

    //answer button objects
    private GameObject answerButtonA;
    private GameObject answerButtonB;
    private GameObject answerButtonC;
    private GameObject answerButtonD;

    //positions at which the answer buttons will be place (the will be randomised)
    private List<GameObject> answerButtonPositions = new List<GameObject>();



    // Use this for initialization
    void Start ()
    {
        //set score to 0
        score = 0;

        //initialize the file paths
        questionFilePath = "Quiz/Questions/";
        answerAFilePath = "Quiz/AnswersA/";
        answerBFilePath = "Quiz/AnswersB/";
        answerCFilePath = "Quiz/AnswersC/";
        answerDFilePath = "Quiz/AnswersD/";
        correctAnswerFilePath = "Quiz/CorrectAnswers/";

        //initialize the question reference to the first question
        questionNumber = 1;

        //intialize the canavs object
        canvas = GameObject.Find("Canvas");

        //initialize question
        question = canvas.transform.Find("Question").gameObject.transform.Find("QuestionText").gameObject;
        questionText = question.GetComponent<Text>();

        //initialize the question buttons
        answerButtonA = canvas.transform.Find("AnswerA").gameObject;
        answerButtonB = canvas.transform.Find("AnswerB").gameObject;
        answerButtonC = canvas.transform.Find("AnswerC").gameObject;
        answerButtonD = canvas.transform.Find("AnswerD").gameObject;

        //add the answer buttons to a list of buttons
        answerButtons.Add(answerButtonA);
        answerButtons.Add(answerButtonB);
        answerButtons.Add(answerButtonC);
        answerButtons.Add(answerButtonD);

        //initialize the answer button texts
        answeButtonAText = answerButtonA.transform.Find("Text").gameObject.GetComponent<Text>();
        answeButtonBText = answerButtonB.transform.Find("Text").gameObject.GetComponent<Text>();
        answeButtonCText = answerButtonC.transform.Find("Text").gameObject.GetComponent<Text>();
        answeButtonDText = answerButtonD.transform.Find("Text").gameObject.GetComponent<Text>();

        //initialize the positions at which the buttons can be placed
        answerButtonPositions.AddRange(GameObject.FindGameObjectsWithTag("QuestionButtonPosition"));
      
        LoadQuestion();
    }

    public void AnswerQuestion(string buttonLetter)
    {
        //depending on what button was pressed, it will run this method, passing in an A, B, C or D as a string
        //so we check on which button was pressed
        switch(buttonLetter)
        {
            case "A":
                //if the answer on that button is correct
               if(answeButtonAText.text == currentAnswer)
                {
                    //increace the players score
                    score++;
                    //then move to next question
                    ChangeQuestion();
                }
               else
                {
                    //if the answer isn't right, just move to the next question
                    ChangeQuestion();
                }
                break;

            case "B":
                if (answeButtonBText.text == currentAnswer)
                {
                    score++;
                    ChangeQuestion();
                }
                else
                {
                    ChangeQuestion();
                }
                break;

            case "C":
                if (answeButtonCText.text == currentAnswer)
                {
                    score++;
                    ChangeQuestion();
                }
                else
                {
                    ChangeQuestion();
                }
                break;

            case "D":
                if (answeButtonDText.text == currentAnswer)
                {
                    score++;
                    ChangeQuestion();
                }
                else
                {
                    ChangeQuestion();
                }
                break;
        }

    }

    //sets the next question up
    void LoadQuestion()
    {
        //get all text assets required for this question ( Question and answer button texts
        activeQuestion = Resources.Load(questionFilePath + "Question" + questionNumber.ToString()) as TextAsset;
        activeAnswerA = Resources.Load(answerAFilePath + "AnswerA" + questionNumber.ToString()) as TextAsset;
        activeAnswerB = Resources.Load(answerBFilePath + "AnswerB" + questionNumber.ToString()) as TextAsset;
        activeAnswerC = Resources.Load(answerCFilePath + "AnswerC"+ questionNumber.ToString()) as TextAsset;
        activeAnswerD = Resources.Load(answerDFilePath + "AnswerD"+ questionNumber.ToString()) as TextAsset;

        //if there isn't a question to load, the quiz is considered over
        if(activeQuestion == null)
        {
            //move to the next scene
            _SceneManager.AdvanceScene();
        }
        else
        {
            //if there is a question, set the relevant texts to the text heald in the text files
            questionText.text = activeQuestion.text;

            answeButtonAText.text = activeAnswerA.text;
            answeButtonBText.text = activeAnswerB.text;
            answeButtonCText.text = activeAnswerC.text;
            answeButtonDText.text = activeAnswerD.text;

            //then get the correct answer from the relevant text file
            activeCurrentAnswer = Resources.Load(correctAnswerFilePath + "CorrectAnswer" + questionNumber.ToString()) as TextAsset;
            currentAnswer = activeCurrentAnswer.text;

            //finally randomise button positions
            RandomiseButtonPositions();
        } 
    }


    //to change the question, simply increace the question number and then re-run the load question method
  public  void ChangeQuestion()
    {
        questionNumber++;
        LoadQuestion();
    }

    public void RandomiseButtonPositions()
    {
        //loop through the answer buttons list and set its position to one randomly selected from
        //the list of positions
        for(int i = 0; i < (answerButtonPositions.Count); i++)
        {
            //get a random button from the list of buttons
            int tempRand = Random.Range(0, (answerButtons.Count));
            //set the buttons position to the position at i
            answerButtons[tempRand].transform.position = answerButtonPositions[i].transform.position;
            //remove that button from the list
            answerButtons.Remove(answerButtons[tempRand]);
        }

        //reset the answer button positions list
        answerButtons.Add(answerButtonA);
        answerButtons.Add(answerButtonB);
        answerButtons.Add(answerButtonC);
        answerButtons.Add(answerButtonD);
    }
}
