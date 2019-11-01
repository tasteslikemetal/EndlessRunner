using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum eState
    {
        COUNTDOWN,
        PLAY,
        PAUSE,
        RESULTS,
        WIN
    }
    public eState state;

    public float multiplierSpeed;
    public int floorThreshold;

    //public PlayerMovement player;
    public int score;

    public int currentLevel = 1;

    public ScoreManager scoreManager;

    public bool canRestart;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        floorThreshold = 3;
        state = eState.PLAY;
        Time.timeScale = 1;
        multiplierSpeed = 1f;
        score = 0;
        canRestart = false;
    }

    private void Update()
    {
        //Debug.Log("currentLevel " + currentLevel);
        if (state == eState.RESULTS)
        {
            DoRestart();
            if (canRestart)
            {
                if (SceneManager.GetActiveScene().name == "EndlessScene")
                {
                    SceneManager.LoadScene("EndlessScene");
                }
                else
                {
                    SceneManager.LoadScene("PlayScene" + currentLevel);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (SceneManager.GetActiveScene().name == "EndlessScene")
                {
                    SceneManager.LoadScene("EndlessScene");
                }
                else
                {
                    SceneManager.LoadScene("PlayScene" + currentLevel);
                }
            }
        }
        if (state == eState.WIN)
        {
            Invoke("NextLevel", 1);
        }
    }

    IEnumerator restartTimer()
    {
        yield return new WaitForSeconds(3);
        canRestart = true;
        //isSuper = false;
        //GameManager.instance.scoreManager.scoreMultiplier /= 10;
    }

    public void DoRestart()
    {
        //isSuper = true;
        //GameManager.instance.scoreManager.scoreMultiplier *= 10;
        StartCoroutine(restartTimer());
    }

    private void FixedUpdate()
    {
        if (LevelGenerator.instance.createdFloors <= floorThreshold || SceneManager.GetActiveScene().name == "StartScene")
        {
            return;
            
        }
        multiplierSpeed += 0.1f;
        LevelGenerator.instance.createdFloors = 0;
        if (multiplierSpeed >= 2.0f && SceneManager.GetActiveScene().name != "EndlessScene")
        {
            LevelGenerator.instance.dropNextLevel = true;
            multiplierSpeed = 1.9f;
        }
    }

    public void NextLevel()
    {
        if (currentLevel == 3)
        {
            SceneManager.LoadScene("EndlessScene");
        }
        else
        {
            SceneManager.LoadScene("PlayScene" + currentLevel);
        }
    }

    public void PauseGame()
    {
        switch (state)
        {
            case eState.PLAY:
                state = eState.PAUSE;
                GameHUDManager.instance.PauseButtonOn();
                Time.timeScale = 0;
                Debug.Log("pause");
                break;
            case eState.PAUSE:
                state = eState.PLAY;
                GameHUDManager.instance.PauseButtonOff();
                Time.timeScale = 1;
                Debug.Log("play");
                break;
        }
    }
}
