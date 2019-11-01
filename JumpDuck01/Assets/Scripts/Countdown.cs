using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    void StartGame()
    {
        //GameManager.instance.state = GameManager.eState.PLAY;
        //SceneManager.LoadScene("PlayScene1");
        Destroy(gameObject);
    }
}
