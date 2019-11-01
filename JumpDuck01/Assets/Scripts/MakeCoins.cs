using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCoins : MonoBehaviour
{
    int randomNum1;
    int randomNum2;
    int randomNum3;
    public List<Transform> coinList;
    public List<Transform> spawnPointsList;

    public Transform super;

    private void Awake()
    {
        randomNum1 = Random.Range(0, 9);
        if(randomNum1 <= 5)
        {
            SpawnCoins1();
        }
        randomNum2 = Random.Range(0, 24);
        if (randomNum2 <= 5)
        {
            SpawnCoins2();
        }
        randomNum3 = Random.Range(0, 49);
        if (randomNum3 <= 5 && randomNum3 != 0)
        {
            SpawnCoins3();
        }
        if (randomNum3 == 0)
        {
            SpawnSuper();
        }
    }

    public void SpawnCoins1()
    {
        Transform randomCoinPattern = coinList[Random.Range(0, coinList.Count)];
        Instantiate(randomCoinPattern, spawnPointsList[0].position, Quaternion.identity);
    }
    public void SpawnCoins2()
    {
        Transform randomCoinPattern = coinList[Random.Range(0, coinList.Count)];
        Instantiate(randomCoinPattern, spawnPointsList[1].position, Quaternion.identity);
    }

    public void SpawnCoins3()
    {
        Transform randomCoinPattern = coinList[Random.Range(0, coinList.Count)];
        Instantiate(randomCoinPattern, spawnPointsList[2].position, Quaternion.identity);
    }

    public void SpawnSuper()
    {
        Instantiate(super, spawnPointsList[2].position, Quaternion.identity);
    }
}
