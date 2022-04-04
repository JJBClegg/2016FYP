using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour {

    Text scoreText;

	// Use this for initialization
	void Start ()
    {
        scoreText = GameObject.Find("Canvas").gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
        scoreText.text = "conratulations on completing the quiz! Your score is : " + QuizManager.score + " please write this score down and thank you very much for playing :)";
	}
	
    //method to take us back to the title screen
    public void GoToTitleScreen()
    {
        _SceneManager.JumpToScene(0);
    }
	
}
