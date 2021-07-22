using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] blockPrefabs;
    [SerializeField] GameManager gameManager;
    void Start()
    {
        InvokeRepeating("SpawnBlock", 0, 6);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBlock()
    {
        if (gameManager.isBlockDelivered)
        {
            Instantiate(blockPrefabs[Random.Range(0, 2)], new Vector3(0, 6, 0), transform.rotation);
            //Instantiate(blockPrefabs[2], new Vector3(0, 200, -2), transform.rotation);
            gameManager.isBlockDelivered = false;
        }
    }
}
