using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Button restartGameButton;
    [SerializeField]
    private Text scoreText, pauseText;

    private int score;
    private void Start()
    {
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }
    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.6f);
        score++;
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }

    private void OnEnable()
    {
        PlayerDied.endGame += PlayerDiedEndGame; 
    }
    private void OnDisable()
    {
        PlayerDied.endGame -= PlayerDiedEndGame;
    }

    void PlayerDiedEndGame()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {
            if (score > PlayerPrefs.GetInt("Score")) PlayerPrefs.SetInt("Score", score);
        }
        pauseText.text = "Game Over!";
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();/////////////////????????
        restartGameButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0f;

    }
    public void PauseButton()
    {
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => ResumeGame());
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("GamePlay");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }
    public void GotoMenu()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("Main Menu");
    }
}
