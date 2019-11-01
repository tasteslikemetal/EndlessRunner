using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaterialChanger : MonoBehaviour
{
    public static MaterialChanger instance;

    public Material currentFloorMaterial;
    public Material level1Material;
    public Material level2Material;
    public Material level3Material;
    public Material EndlessMaterial;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        currentFloorMaterial = GetComponent<MeshRenderer>().material;

        if (GameManager.instance.currentLevel == 1)
        {
            //currentFloorMaterial = level1Material;
            GetComponent<MeshRenderer>().material = level1Material;

        }
        if (GameManager.instance.currentLevel == 2)
        {
            //currentFloorMaterial = level2Material;
            GetComponent<MeshRenderer>().material = level2Material;
        }
        if (GameManager.instance.currentLevel == 3)
        {
            //currentFloorMaterial = level3Material;
            GetComponent<MeshRenderer>().material = level3Material;
        }
        if (SceneManager.GetActiveScene().name == "EndlessScene")
        {
            //currentFloorMaterial = EndlessMaterial;
            GetComponent<MeshRenderer>().material = EndlessMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
