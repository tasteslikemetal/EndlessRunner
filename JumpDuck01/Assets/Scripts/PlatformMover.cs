using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public static PlatformMover instance;

    public float SPEED = 6;

    public float endPos;
    public float spawnPos;

    //[SerializeField] private Transform endOfPiece;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        foreach (Transform trans in transform)
        {
            trans.position += Vector3.left * Time.deltaTime * (SPEED * GameManager.instance.multiplierSpeed);
            if (trans.localPosition.x < endPos)
            {
                //trans.localPosition = new Vector3(spawnPos, trans.localPosition.y, trans.localPosition.z);//moves to right
                //LevelGenerator.instance.SpawnLevelPart();
                Destroy(trans.gameObject);//Destroys - use if instantiating
            }
        }
    }
}
