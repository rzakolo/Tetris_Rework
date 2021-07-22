using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    [SerializeField] float blockSpeed;
    [SerializeField] GameManager gameManager;
    Rigidbody2D blockRb;
    bool stopBlock = true;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        blockSpeed = gameManager.blockSpeed;
        blockRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isBlockDelivered)
        {
            blockRb.AddForce(Vector3.down * blockSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Background" && stopBlock)
        {
            gameManager.isBlockDelivered = true;
            stopBlock = false;
        }

    }
}
