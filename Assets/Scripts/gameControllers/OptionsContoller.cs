using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsContoller : MonoBehaviour
{
    [SerializeField]
	private GameObject easySign, mediumSign, hardSign;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialDifficultyInOptionsMenu ();
    }
    public void InitialDifficulty(string difficulty) {
		switch (difficulty) {
		case "easy":
			easySign.SetActive (true);
			mediumSign.SetActive (false);
			hardSign.SetActive (false);
			break;

		case "medium":
			easySign.SetActive (false);
			mediumSign.SetActive (true);
			hardSign.SetActive (false);
			break;

		case "hard":
			easySign.SetActive (false);
			mediumSign.SetActive (false);
			hardSign.SetActive (true);
			break;
		}
	}

	void SetInitialDifficultyInOptionsMenu() {
		if(GamePreferences.GetEasyDifficultyState() == 0) {
			InitialDifficulty("easy");
		} 
		
		if(GamePreferences.GetMediumDifficultyState() == 0) {
			InitialDifficulty("medium");
		} 
		
		if(GamePreferences.GetHardDifficultyState() == 0) {
			InitialDifficulty("hard");
		} 
	}

	public void EasyDifficulty() {

		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (1);
		GamePreferences.SetHardDifficultyState (1);

		easySign.SetActive (true);
		mediumSign.SetActive (false);
		hardSign.SetActive (false);
	}

	public void MediumDifficulty() {

		GamePreferences.SetEasyDifficultyState (1);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (1);

		easySign.SetActive (false);
		mediumSign.SetActive (true);
		hardSign.SetActive (false);
	}

	public void HardDifficulty() {

		GamePreferences.SetEasyDifficultyState (1);
		GamePreferences.SetMediumDifficultyState (1);
		GamePreferences.SetHardDifficultyState (0);

		easySign.SetActive (false);
		mediumSign.SetActive (false);
		hardSign.SetActive (true);
	}

    public void BackTOmainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }


}
