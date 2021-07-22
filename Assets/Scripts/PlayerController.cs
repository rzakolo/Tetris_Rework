using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 horizontal = new Vector3(1, 0, 0);
    Vector3 vertical = new Vector3(0, -1, 0);
    GameManager gameManager;
    bool isActive = true;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {

        if (gameManager.isBlockDelivered)
        {
            isActive = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && isActive)
        {
            transform.Translate(horizontal, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.A) && isActive)
        {
            transform.Translate(-horizontal, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.S) && isActive)
        {
            transform.Translate(vertical, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90);
        }
    }
}
