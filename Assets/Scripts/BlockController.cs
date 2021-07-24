using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    Vector3 horizontal = new Vector3(1, 0, 0);
    Vector3 vertical = new Vector3(0, 1, 0);
    GameManager gameManager;
    bool isActive = true;
    [SerializeField]
    private float blockFallTime = 0.9f;
    private float previousTime;
    int height = 20;
    int widht = 10;
    public static Transform[,] table = new Transform[10, 20];


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += horizontal;
                if (!ValidMove()) { transform.position -= horizontal; }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position -= horizontal;
                if (!ValidMove()) { transform.position += horizontal; }
            }
            if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.S) ? blockFallTime / 10 : blockFallTime))
            {
                transform.position -= vertical;
                previousTime = Time.time;
                if (!ValidMove())
                {
                    transform.position += vertical;
                    AddToTable();
                    gameManager.isBlockDelivered = true;
                    isActive = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90);
                if (!ValidMove())
                {
                    transform.RotateAround(transform.position, new Vector3(0, 0, 1), 90);
                }
            }
            CheckLines();
        }
    }
    void AddToTable()
    {
        foreach (Transform item in transform)
        {
            int roundedX = Mathf.RoundToInt(item.transform.position.x);
            int roundedY = Mathf.RoundToInt(item.transform.position.y);
            table[roundedX, roundedY] = item;
        }
    }
    void CheckLines()
    {
        int counter = 0;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < widht; j++)
            {
                if (table[j, i] != null) counter++;
                if (counter == 10)
                {
                    DestroyLine(i);
                    RowDown(i);
                }
            }
            counter = 0;
        }
    }

    private void RowDown(int i)
    {
        for (int j = i; j < height; j++)
        {
            for (int y = 0; y < widht; y++)
            {
                if (table[y, j] != null)
                {
                    table[y, j - 1] = table[y, j];
                    table[y, j] = null;
                    table[y, j - 1].transform.position -= vertical;
                }
            }
        }
    }

    private void DestroyLine(int line)
    {
        for (int j = 0; j < widht; j++)
        {
            Destroy(table[j, line].gameObject);
            table[j, line] = null;
        }
    }

    bool ValidMove()
    {
        foreach (Transform item in transform)
        {
            int roundedX = Mathf.RoundToInt(item.transform.position.x);
            int roundedY = Mathf.RoundToInt(item.transform.position.y);
            if (roundedX < 0 || roundedX >= widht || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (table[roundedX, roundedY] != null)
            {
                return false;
            }

        }

        return true;
    }
}
