using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHUDManager : MonoBehaviour
{
    public static GameHUDManager instance;

    public TMP_Text txtHighScore;
    public TMP_Text txtScore;
    public TMP_Text txtLevel;

    public TMP_Text txtHighScoreLVL1;
    public TMP_Text txtHighScoreLVL2;
    public TMP_Text txtHighScoreLVL3;
    public TMP_Text txtHighScoreLVLEndless;

    public GameObject countdownCANVAS;
    public GameObject highScoresCANVAS;
    public GameObject mainMenuCANVAS;
    public GameObject controlsCANVAS;
    public GameObject pauseCANVAS;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "PlayScene1")
        {
            txtHighScore.text = "High: " + PlayerPrefs.GetInt("lvl1SCORE", 0);
            txtLevel.text = "Level 1";
        }
        if (SceneManager.GetActiveScene().name == "PlayScene2")
        {
            txtHighScore.text = "High: " + PlayerPrefs.GetInt("lvl2SCORE", 0);
            txtLevel.text = "Level 2";
        }
        if (SceneManager.GetActiveScene().name == "PlayScene3")
        {
            txtHighScore.text = "High: " + PlayerPrefs.GetInt("lvl3SCORE", 0);
            txtLevel.text = "Level 3";
        }
        if (SceneManager.GetActiveScene().name == "EndlessScene")
        {
            txtHighScore.text = "High: " + PlayerPrefs.GetInt("lvlEndlessSCORE", 0);
            txtLevel.text = "Endless Mode";
        }

        txtScore.text = GameManager.instance.score + "";

        if (txtHighScoreLVL1 == null)//prevents errors on non start lvls
        {
            return;
        }
        txtHighScoreLVL1.text = PlayerPrefs.GetInt("lvl1SCORE", 0) + "";
        txtHighScoreLVL2.text = PlayerPrefs.GetInt("lvl2SCORE", 0) + "";
        txtHighScoreLVL3.text = PlayerPrefs.GetInt("lvl3SCORE", 0) + "";
        txtHighScoreLVLEndless.text = PlayerPrefs.GetInt("lvlEndlessSCORE", 0) + "";
    }

    private void Update()
    {
        txtScore.text = GameManager.instance.score.ToString();
    }

    public void ResumeButton()
    {
        GameManager.instance.PauseGame();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScene1");
        //mainMenuCANVAS.SetActive(false);
        //countdownCANVAS.SetActive(true);
    }
    public void ScoresButton()
    {
        mainMenuCANVAS.SetActive(false);
        highScoresCANVAS.SetActive(true);
    }
    public void ControlsButton()
    {
        mainMenuCANVAS.SetActive(false);
        controlsCANVAS.SetActive(true);
    }
    public void BackButton()
    {
        highScoresCANVAS.SetActive(false);
        controlsCANVAS.SetActive(false);
        mainMenuCANVAS.SetActive(true);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void PauseButtonOn()
    {
        pauseCANVAS.SetActive(true);
    }
    public void PauseButtonOff()
    {
        pauseCANVAS.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }


}
