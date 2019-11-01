using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    float tmpScore;

    public float scoreMultiplier;

    private void Start()
    {
        tmpScore = 0;

        if (SceneManager.GetActiveScene().name == "PlayScene1")
        {
            scoreMultiplier = 10;
        }
        if (SceneManager.GetActiveScene().name == "PlayScene2")
        {
            scoreMultiplier = 20;
        }
        if (SceneManager.GetActiveScene().name == "PlayScene3")
        {
            scoreMultiplier = 30;
        }
        if (SceneManager.GetActiveScene().name == "EndlessScene")
        {
            scoreMultiplier = 100;
        }

    }


    void Update()
    {
        if (GameManager.instance.state != GameManager.eState.PLAY)
        {
            return;
        }

        tmpScore += Time.deltaTime * (scoreMultiplier * GameManager.instance.multiplierSpeed);//score over time

        GameManager.instance.score = (int)tmpScore;
    }

    public void AddScore(int p_val)
    {
        tmpScore += p_val;
    }

    public void SaveScore()
    {
        if (SceneManager.GetActiveScene().name == "PlayScene1")
        {
            if (PlayerPrefs.GetInt("lvl1SCORE", 0) < GameManager.instance.score)
            {
                PlayerPrefs.SetInt("lvl1SCORE", GameManager.instance.score);
            }
        }

        if (SceneManager.GetActiveScene().name == "PlayScene2")
        {
            if (PlayerPrefs.GetInt("lvl2SCORE", 0) < GameManager.instance.score)
            {
                PlayerPrefs.SetInt("lvl2SCORE", GameManager.instance.score);
            }
        }

        if (SceneManager.GetActiveScene().name == "PlayScene3")
        {
            if (PlayerPrefs.GetInt("lvl3SCORE", 0) < GameManager.instance.score)
            {
                PlayerPrefs.SetInt("lvl3SCORE", GameManager.instance.score);
            }
        }

        if (SceneManager.GetActiveScene().name == "EndlessScene")
        {
            if (PlayerPrefs.GetInt("lvlEndlessSCORE", 0) < GameManager.instance.score)
            {
                PlayerPrefs.SetInt("lvlEndlessSCORE", GameManager.instance.score);
            }
        }

        PlayerPrefs.Save();
    }
}
