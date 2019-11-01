using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public static MovePlatforms instance;

    public float SPEED = 6;

    public float endPos;

    private void Awake()
    {
        instance = this;
    }


    private void FixedUpdate()
    {
        if (GameManager.instance.state != GameManager.eState.PLAY)
        {
            return;
        }
        transform.position += Vector3.left * Time.deltaTime * (SPEED * GameManager.instance.multiplierSpeed);
        if (transform.localPosition.x  < endPos)
        {
            //LevelGenerator.instance.canSpawn = true;
            LevelGenerator.instance.remainingFloors--;
            Destroy(gameObject);
        }
        
    }
}
