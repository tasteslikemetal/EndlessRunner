using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgrounds : MonoBehaviour
{
    public static MoveBackgrounds instance;

    public float SPEED = 0.5f;

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
        if (transform.localPosition.x < endPos)
        {
            //LevelGenerator.instance.canSpawn = true;
            BackgroundGenerator.instance.remainingBackgrounds--;
            Destroy(gameObject);
        }

    }
}
