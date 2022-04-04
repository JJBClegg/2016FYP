using UnityEngine;
using System.Collections;

public class MainCharController : MonoBehaviour {

	[SerializeField]
	float _charMoveSpeed; //the characters speed (best at 0.2 for normal)
	private bool _ableToMove;

	private bool _touchingItem;
	private GameObject _touchedItem;

	// Use this for initialization
	void Start () {
		_touchingItem = false;
		_ableToMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		ExamineObject ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//when collided with an item, get a refference to it.
		if (col.tag == "item" || col.tag == "DoorItem") 
		{
			Debug.Log("colliding with" + col.name);
			_touchingItem = true;
			_touchedItem = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		//when leaving an items collision, remove the refference to the item.
		if (col.tag == "item" || col.tag == "DoorItem") 
		{
			Debug.Log ("not touching item");
			_touchingItem = false;
			_touchedItem = null;
		}
	}

	void ExamineObject()
	{
		//when colliding with an item, examine it with the E key.
		if (Input.GetKeyUp (KeyCode.E) && _touchingItem) 
		{
			_touchedItem.GetComponent<_ItemScript>().Examine();
		}
	}

	//Method to handle player movement through input, if they are able to move of course.
	void Move()
	{
		if (_ableToMove) 
		{
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				gameObject.transform.Translate(0.0f,_charMoveSpeed,0.0f,Space.World);
			}
			
			if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				gameObject.transform.Translate(0.0f,-_charMoveSpeed,0.0f,Space.World);
			}
			
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				gameObject.transform.Translate(_charMoveSpeed,0.0f,0.0f,Space.World);
			}
			
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				gameObject.transform.Translate(-_charMoveSpeed,0.0f,0.0f,Space.World);
			}
		}
	}

	public void SetMovementConstraint(bool value)
	{
		_ableToMove = value;
	}
}
