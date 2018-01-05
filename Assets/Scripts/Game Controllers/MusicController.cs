using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
		audioSource = GetComponent<AudioSource> ();
	}

	void MakeSingleton(){
		if (instance != null) {
			Destroy (gameObject);
		} else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	// Update is called once per frame
	public void PlayMusic (bool play) {
		if (play) {
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
		} else {
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}
		}
	}
}
