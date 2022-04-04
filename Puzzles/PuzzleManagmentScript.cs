using UnityEngine;
using System.Collections;

public class PuzzleManagmentScript : MonoBehaviour
{
	//PUZZLE STUFF
	bool puzzleModeActive;
	bool puzzleComplete;

	//CANVAS STUFF
	GameObject _canvas;

	//CAMERA MOVEMENT STUFF
	Vector3 puzzleCamPosition;
	GameObject playerObject;
	MainCharController playerScript;
	GameObject playerCamera;

	//MOUSE INPUT STUFF
	bool _mouseDown;
	private Vector3 _mouseTouchPos;
	private GameObject _selectedObject;

	//ATTATCHED DOOR
	private DoorScript attatchedDoor;

	// Use this for initialization
	void Start ()
	{
		_canvas = GameObject.Find ("Canvas");
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerScript = playerObject.GetComponent<MainCharController> ();
		playerCamera = playerObject.transform.Find ("Main Camera").gameObject;
		puzzleCamPosition = GameObject.FindGameObjectWithTag ("PuzzleCameraPosition").transform.position;
		attatchedDoor = GameObject.FindGameObjectWithTag ("DoorItem").GetComponent<DoorScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (puzzleModeActive) 
		{
			MoveCameraToPuzzle();
			HandleMouseInput ();

			_canvas.transform.Find ("Solve Button").gameObject.SetActive(true);

			if(Input.GetKeyDown(KeyCode.Escape))
			{
				puzzleModeActive = false;
			}

			if (puzzleComplete) 
			{
				attatchedDoor.SetUnlockedState(true);
			}
		} 
		else 
		{
			_canvas.transform.Find ("Solve Button").gameObject.SetActive(false);
			MoveCameraToPlayer();
		}

	}

	public void SetPuzzleCompletion(bool value)
	{
		puzzleComplete = value;
	}

	public void SetPuzzleActive(bool value)
	{
		puzzleModeActive = value;
	}

	public bool GetPuzzleCompletion()
	{
		return puzzleComplete;
	}

	void MoveCameraToPuzzle()
	{
		playerCamera.transform.position = puzzleCamPosition;
		playerScript.SetMovementConstraint (false);
	}

	void MoveCameraToPlayer()
	{
		playerCamera.transform.position = new Vector3(playerObject.transform.position.x,
		                                              playerObject.transform.position.y,
		                                              (playerObject.transform.position.z - 10.0f));
		playerScript.SetMovementConstraint (true);
	}

	void HandleMouseInput()
	{
		if (Input.GetMouseButtonUp (0)) 
		{
			_mouseDown = false;
		}
		
		if (Input.GetMouseButtonDown (0)) 
		{
			_mouseDown = true;
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) 
			{
				if (hit.collider.tag == "puzzle piece") 
				{
					_selectedObject = hit.collider.gameObject;
				} 
				else 
				{
					Debug.Log (hit.collider);
				}
			}
		} 
		
		if (_mouseDown) {
			if (_selectedObject != null) {
				_mouseTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 _originalObjPos = _selectedObject.transform.position;
				_originalObjPos.y = _mouseTouchPos.y;
				_originalObjPos.x = _mouseTouchPos.x;
				_selectedObject.transform.position = _originalObjPos;
				_originalObjPos = _selectedObject.transform.position;
			}
		} 
		else 
		{
			_selectedObject = null;
		}
	}
}
