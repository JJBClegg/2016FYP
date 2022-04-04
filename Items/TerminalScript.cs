using UnityEngine;
using System.Collections;

public class TerminalScript : _ItemScript {

	PuzzleManagmentScript puzzleManager;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		puzzleManager = GameObject.FindGameObjectWithTag ("PuzzleManager").GetComponent<PuzzleManagmentScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_examined) 
		{
			puzzleManager.SetPuzzleActive(true);
			_examined = false;
		}
	}
}
