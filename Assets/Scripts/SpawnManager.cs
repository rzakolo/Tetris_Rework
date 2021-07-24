using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] blockPrefabs;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBlock), 0, 6);
    }
    void SpawnBlock()
    {
        if (gameManager.isBlockDelivered)
        {
            GameObject currentBlock = blockPrefabs[Random.Range(0, 3)];
            Instantiate(currentBlock, transform.position, transform.rotation);
            //Instantiate(blockPrefabs[2], new Vector3(0, 200, -2), transform.rotation);
            gameManager.isBlockDelivered = false;
        }
    }
}
