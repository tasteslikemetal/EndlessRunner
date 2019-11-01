using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    public List<Transform> levelPartList;
    public Transform levelPart_Start;
    public Transform endLevelPart;

    private Vector3 lastEndPosition;
    Transform lastTransform;

    public int remainingFloors;

    int startingFloors = 3;

    public int createdFloors;

    public bool dropNextLevel;

    //public List<Transform> coinPatternList;
    //public Transform coinStart;

    //private Vector3 lastcoinPatternPosition;
    //Transform lastCoinTransform;

       
    //bool spawnCoinPattern;


    private void Awake()
    {
        instance = this;

        lastTransform = levelPart_Start;
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        //lastCoinTransform = coinStart;
        //lastcoinPatternPosition = coinStart.Find("CoinSpawnPoint1").position;
    }

    private void Start()
    {
        createdFloors = startingFloors;
        remainingFloors = startingFloors;
        dropNextLevel = false;
        
        //spawnCoinPattern = false;

        for (int i = 0; i < startingFloors; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (remainingFloors < startingFloors)
        {
            SpawnLevelPart();
            remainingFloors++;
            createdFloors++;
        }
        if (dropNextLevel)//bool used for next level spawn
        {            
            SpawnEndLevelPart();
            remainingFloors++;
            createdFloors++;
            dropNextLevel = false;
        }

    }
    public void SpawnEndLevelPart()//spawn specific level part with next level collider
    {
        Transform lastLevelPartTransform = SpawnLevelPart(endLevelPart, lastTransform.Find("EndPosition").position);
        lastTransform = lastLevelPartTransform;
    }

    public void SpawnLevelPart()//gets random part and puts at last parts end position
    {
        Transform randomLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(randomLevelPart, lastTransform.Find("EndPosition").position);
        lastTransform = lastLevelPartTransform;
    }
    Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    /*
    public void SpawnCoins()
    {
        int coinDropYesNo = 9;
        //int coinDropYesNo = Random.Range(0, 9);
        if(coinDropYesNo >= 8)
        {
            Transform randomCoinPattern = coinPatternList[Random.Range(0, coinPatternList.Count)];
            Transform lastCoinPatternTransform = SpawnCoins(randomCoinPattern, lastCoinTransform.Find("CoinSpawnPoint1").position);
            lastCoinTransform = lastCoinPatternTransform;
        }
    }
    Transform SpawnCoins(Transform coins, Vector3 spawnposition)
    {
        Transform coinTransform = Instantiate(coins, spawnposition, Quaternion.identity);
        return coinTransform;
    }
    */
    #region not using offset
    public void SpawnLevelPart2()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart2(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    Transform SpawnLevelPart2(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform =  Instantiate(levelPart, new Vector3(spawnPosition.x - 20, spawnPosition.y, spawnPosition.z), Quaternion.identity);
        return levelPartTransform;
    }
    #endregion
}
