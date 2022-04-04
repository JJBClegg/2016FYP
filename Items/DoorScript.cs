using UnityEngine;
using System.Collections;

public class DoorScript : _ItemScript {

	private bool unlocked;


	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_examined) 
		{
			if(unlocked)
			{
                _SceneManager.AdvanceScene();
			}
			_examined = false;
		}
	}

	public void SetUnlockedState(bool value)
	{
		unlocked = value;
	}
}
