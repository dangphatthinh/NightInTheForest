using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private Button tutorialButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject pausePanel;

    private void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }
    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void TutorialButton()
    {
        Time.timeScale = 1;
        tutorialButton.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void _ShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = score.ToString();
        if (score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHighScore();
    }
    public void _QuitButton()
    {
        Application.Quit();
    }
    public void _ResumeButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void _PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void _ResumeButtonPause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
