using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextItem : _ItemScript {

	string _textAssetsPath; //path to the folder in which all text assets are stored
	int activeText = 1;
	TextAsset _displayText;//refference to the text that should be displayed
	GameObject _textDisplayObject;//refference to the UI component that will display the text
	GameObject _textBackdrop;//refference to the UI conmpontent that will supply a backdrop to the text
	[SerializeField]
	string lessonText;//Change this to display text revlevant to the lesson atr hadn ("level01-" would be for level ect... DON'T FORGET THE DASH AT THE END!)

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();//initialize the base
		_textAssetsPath = "TextAssets/";//set path to the text assets in the resources folder
		_displayText = Resources.Load (_textAssetsPath + lessonText + activeText.ToString()) as TextAsset;//load in the first instance of text
		//get reference to the UI text component
		_textDisplayObject = _canvasObject.transform.Find ("TextDisplay").gameObject.transform.Find ("Text").gameObject;
		//get refference to the backdrop
		_textBackdrop = _canvasObject.transform.Find ("TextDisplay").gameObject.transform.Find ("Image").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_examined) 
		{
			//when the object is being examined, then set the text to the correct text file
			DisplayText();

			//when the player presses escape, disable all active text UI components
			if (Input.GetKeyUp (KeyCode.Escape) && _textBackdrop.activeSelf && _textDisplayObject.activeSelf)
			{
				ExitTextDisplay();
			}

			if(Input.GetKeyUp(KeyCode.Space) && _textBackdrop.activeSelf && _textDisplayObject.activeSelf)
			{
				activeText++;
				SetActiveText();
			}
		}
	}

	void SetActiveText()
	{
		_displayText = Resources.Load (_textAssetsPath + lessonText + activeText.ToString()) as TextAsset;
		if (_displayText == null) 
		{
			ExitTextDisplay();
			activeText = 1;
			_displayText = Resources.Load (_textAssetsPath + lessonText + activeText.ToString()) as TextAsset;
		}
	}

	void DisplayText()
	{
		_textDisplayObject.GetComponent	<Text>().text = _displayText.text;
		_canvasObject.transform.Find("TextDisplay").gameObject.SetActive(true);
		_textBackdrop.SetActive(true);
		_textDisplayObject.SetActive(true);
	}
	
	void ExitTextDisplay()
	{
		_canvasObject.transform.Find("TextDisplay").gameObject.SetActive(false);
		_textBackdrop.SetActive(false);
		_textDisplayObject.SetActive(false);
		_examined = false;
	}
}
