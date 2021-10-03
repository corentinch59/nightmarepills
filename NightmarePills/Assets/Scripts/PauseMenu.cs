using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private GameObject GameUI;
    private GameObject PauseUI;
    private TextMeshProUGUI pauseScore;

    public static bool GameIsPaused = false;

    void Start()
    {
        GameUI = GameObject.Find("Game");
        PauseUI = GameObject.Find("Pause");
        pauseScore = GameObject.Find("PauseScore").GetComponent<TextMeshProUGUI>();

        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.gameIsOver)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseScore.text = "Your Score : " + GameManager.instance.score.ToString();

        GameUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
