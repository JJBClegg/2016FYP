using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// THIS CLASS IS TO BE USED FOR ANY ITEM THAT IS DESIGNED TO PLAYE A VIDEO WHEN EXAMINED.
/// IT WILL EXTEND THE BASE ITEM CLASS
/// </summary>

public class VideoItem : _ItemScript {

	[SerializeField] MovieTexture attatchedVideo; //the video the item will play.
       
                                              
    [SerializeField]
    GameObject bgaudioManager;
    AudioManager bgaudioManagerSource;

    AudioSource videoAudioSource;

	private GameObject _videoComponent; //this is the game object that will be used to display a video through the UI

	// Use this for initialization
	protected override void Start ()
    {
		base.Start ();
		_videoComponent = _canvasObject.transform.Find ("Video").gameObject;
		_videoComponent.SetActive (false);
        bgaudioManagerSource = bgaudioManager.GetComponent<AudioManager>();
        videoAudioSource = GameObject.Find("VideoAudioSource").GetComponent<AudioSource>();
        if(videoAudioSource == null)
        {
            Debug.Log("no source found");
        }
        else
        {
            Debug.Log(videoAudioSource);
        }

	}
	
	// Update is called once per frame
	void Update () {

		if (_examined)
		{
			_videoComponent.SetActive(true);
			GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharController>().SetMovementConstraint(false);
            videoAudioSource.clip = attatchedVideo.audioClip;
            if(!attatchedVideo.isPlaying)
            {
                attatchedVideo.Play();
                videoAudioSource.Play();
            }
            bgaudioManagerSource.Stop();
            
		}

		if (Input.GetKeyUp (KeyCode.Escape) && attatchedVideo.isPlaying)
		{
			_examined = false;
			attatchedVideo.Stop();
            videoAudioSource.Stop();
            bgaudioManagerSource.StartSound();
		}

		if (!attatchedVideo.isPlaying) 
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharController>().SetMovementConstraint(true);
			_videoComponent.SetActive(false);
		}
	}
}
