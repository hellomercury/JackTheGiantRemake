﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
		CheckToPlayTheMusic ();
	}

	void CheckToPlayTheMusic(){
		if (GamePreferences.GetMusicState () == 1) {
			MusicController.instance.PlayMusic (true);
			musicBtn.image.sprite = musicIcons [1];
		} else {
			MusicController.instance.PlayMusic (false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}

	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
		//SceneManager.LoadScene ("Gameplay");
		//Application.LoadLevel ("Gameplay");
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void HighscoreMenu(){
		SceneManager.LoadScene ("HighscoreScene");
		//Application.LoadLevel ("HighscoreScene");
	}

	public void OptionseMenu(){
		SceneManager.LoadScene ("OptionsMenu");
		//Application.LoadLevel ("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void MusicButton(){
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState (1);
			MusicController.instance.PlayMusic (true);
			musicBtn.image.sprite = musicIcons [1];
		} else {
			GamePreferences.SetMusicState (0);
			MusicController.instance.PlayMusic (false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}
}
