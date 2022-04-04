using UnityEngine;
using System.Collections;

public class puzzlePiece : MonoBehaviour {

	[SerializeField]
	string pieceType;

	public string GetPieceType()
	{
		return pieceType;
	}
}
