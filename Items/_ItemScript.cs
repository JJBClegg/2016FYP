using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _ItemScript : MonoBehaviour {

	protected bool _examined;
	protected GameObject _canvasObject;


	// constructor
	protected virtual void Start() 
	{
		_examined = false;
		_canvasObject = GameObject.Find ("Canvas");
	}
	
	public void Examine()
	{
		_examined = true;
	}
}
