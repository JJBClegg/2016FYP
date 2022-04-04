using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClassSections : MonoBehaviour {

	[SerializeField]
	private string attatchedPieceType;
	private string area;
	private bool areaComplete;
	private bool possibleToCompletePuzzle;
	private int numOfPiecesPlaced;
	[SerializeField]
	private List<GameObject> attatchedPieces;
	private PuzzleManagmentScript puzzleManager;
	static private int numberOfAreas = 0;
	static private int numOfAreasComplete;

	// Use this for initialization
	void Start () {
		numberOfAreas++;
		puzzleManager = GameObject.FindGameObjectWithTag ("PuzzleManager").GetComponent<PuzzleManagmentScript> ();
		area = gameObject.name;
		attatchedPieces.AddRange(GameObject.FindGameObjectsWithTag ("puzzle piece"));

		for (int i = 0; i < attatchedPieces.Count; i++)
		{
			if(attatchedPieces[i].GetComponent<puzzlePiece> ().GetPieceType() != attatchedPieceType)
			{
				attatchedPieces.Remove(attatchedPieces[i]);
				i = -1;
			}
 		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < attatchedPieces.Count; i++)
		{
			if(gameObject.GetComponent<BoxCollider2D>().bounds.Contains(attatchedPieces[i].transform.position))
			{
				numOfPiecesPlaced ++;
			}

		}

		if (numOfPiecesPlaced == attatchedPieces.Count && !areaComplete) {
			numOfAreasComplete++;
			areaComplete = true;
		} 

		else if (numOfAreasComplete == numberOfAreas && !puzzleManager.GetPuzzleCompletion()) 
		{
			possibleToCompletePuzzle = true;
		}

		else if(numOfPiecesPlaced != attatchedPieces.Count)
		{
			numOfPiecesPlaced = 0;
		}

	}

	public void CompletePuzzle()
	{
		if (possibleToCompletePuzzle) 
		{
			Debug.Log ("puzzle complete");
			puzzleManager.SetPuzzleCompletion(true);
			numberOfAreas = 0;
		}
	}
}
