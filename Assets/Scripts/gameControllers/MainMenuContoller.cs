using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuContoller : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

         
    void Start()
    {
        CheckIfMusicIsOnOrOff ();
    }
       
    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Game");
    }

    void CheckIfMusicIsOnOrOff()
    { 
        //if (GamePreferences.GetMusicState () == 1) {
        //	if (MusicController.instance != null) {
        //		MusicController.instance.PlayMusic (true);
        //	}
        //	musicButton.image.sprite = musicIcons[1];
        //} else {
        //	musicButton.image.sprite = musicIcons[0];
        //}

        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }

    }

    public void HighScoreMenu()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if (GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else if (GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }
}
