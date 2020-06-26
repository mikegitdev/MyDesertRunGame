using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreController : MonoBehaviour
{
	[SerializeField]
	private TMP_Text scoreText, coinText;

	// Start is called before the first frame update
	void Start()
	{
		SetScoreForDifficulty ();
		//Gamaplaycontroller.instance.SomeMethod();
	}
	public void SetScore(int score, int coin) {
		scoreText.text = "" + score;
		coinText.text = "" + coin;
	}

	void SetScoreForDifficulty() {
		if(GamePreferences.GetEasyDifficultyState() == 0) {
			SetScore(GamePreferences.GetEasyDifficultyHighscore(), GamePreferences.GetEasyDifficultyCoinScore());
		} 
		
		if(GamePreferences.GetMediumDifficultyState() == 0) {
			SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinScore());
		} 
		
		if(GamePreferences.GetHardDifficultyState() == 0) {
			SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinScore());
		} 
	}

	public void GoBackToMainMenu()
	{
		SceneManager.LoadScene("mainMenu");

	}
   


}
