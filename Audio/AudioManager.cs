using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour {

    AudioSource audioSource;
    
    
	// Use this for initialization
	void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
    public void Stop()
    {
        audioSource.Pause();
    }

    public void StartSound()
    {
        audioSource.Play();
    }
}
