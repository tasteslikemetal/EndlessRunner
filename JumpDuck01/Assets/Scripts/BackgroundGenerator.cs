using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public static BackgroundGenerator instance;

    public List<Transform> BGPartList;
    public Transform BackgroundSection_Start;

    public List<Transform> BGPart2List;
    public Transform BackgroundSection2_Start;

    private Vector3 lastEndPostion;
    Transform lastTransform;

    private Vector3 lastEndPostion2;
    Transform lastTransform2;

    int startingBackgrounds = 1;
    public int remainingBackgrounds;
    public int remainingBackgrounds2;

    //public Material currentBGInnerMaterial;
    //public Material currentBGOuterMaterial;

    private void Awake()
    {
        instance = this;
        lastTransform = BackgroundSection_Start;
        lastEndPostion = BackgroundSection_Start.Find("EndPosition").position;

        lastTransform2 = BackgroundSection2_Start;
        lastEndPostion2 = BackgroundSection2_Start.Find("EndPosition").position;
    }

    private void Start()
    {
        remainingBackgrounds = startingBackgrounds;
        remainingBackgrounds2 = startingBackgrounds;

        for (int i = 0; i < startingBackgrounds; i++)
        {
            SpawnBackgroundLayer();
            SpawnBackgroundLayer2();
        }
    }

    private void Update()
    {
        if (remainingBackgrounds < startingBackgrounds)
        {
            SpawnBackgroundLayer();
            remainingBackgrounds++;
        }
        if (remainingBackgrounds2 < startingBackgrounds)
        {
            SpawnBackgroundLayer2();
            remainingBackgrounds2++;
        }
    }

    public void SpawnBackgroundLayer2()
    {
        Transform randomBG2Part = BGPart2List[Random.Range(0, BGPart2List.Count)];
        Transform lastBG2PartTransform = SpawnBackgroundLayer2(randomBG2Part, lastTransform2.Find("EndPosition").position);
        lastTransform2 = lastBG2PartTransform;
    }
    Transform SpawnBackgroundLayer2(Transform BGPart, Vector3 spawnPosition)
    {
        Transform BGPartTransform = Instantiate(BGPart, spawnPosition, Quaternion.identity);
        return BGPartTransform;
    }

    public void SpawnBackgroundLayer()
    {
        Transform randomBGPart = BGPartList[Random.Range(0, BGPartList.Count)];
        Transform lastBGPartTransform = SpawnBackgroundLayer(randomBGPart, lastTransform.Find("EndPosition").position);
        lastTransform = lastBGPartTransform;
    }
    Transform SpawnBackgroundLayer(Transform BGPart, Vector3 spawnPosition)
    {
        Transform BGPartTransform = Instantiate(BGPart, spawnPosition, Quaternion.identity);
        return BGPartTransform;
    }


}
