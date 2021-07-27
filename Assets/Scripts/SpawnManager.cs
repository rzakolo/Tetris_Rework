using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] blockPrefabs;
    [SerializeField] GameManager gameManager;
    private GameObject currentBlock;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBlock), 0, 3);
        currentBlock = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
    }
    void SpawnBlock()
    {
        if (gameManager.isBlockDelivered && !gameManager.isGameOver)
        {
            Instantiate(currentBlock, transform.position, transform.rotation);
            currentBlock = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
            gameManager.Block = currentBlock;
            gameManager.isBlockDelivered = false;
        }
    }
}
