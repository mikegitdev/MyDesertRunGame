using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Gamaplaycontroller : MonoBehaviour
{
    public static Gamaplaycontroller instance;


    [SerializeField]
    private TMP_Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject GamePaused, GameOver;

    [SerializeField]
    private GameObject readyButton;

    
    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        Time.timeScale = 0f;
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    public void GameOverShowPanel(int finalScore, int finalCoinSXore)
    {
        GameOver.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinSXore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
    public void SetScore(int score)
    {
        scoreText.text = "x"+ score;

    }
    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;

    }
    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        GamePaused.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GamePaused.SetActive(false);
    }
   
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void StartReady()
    {
        Time.timeScale = 1f;
        readyButton.gameObject.SetActive(false);
    }


}
