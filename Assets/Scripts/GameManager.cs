using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float blockSpeed;
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] Button restartButton;
    public bool isGameOver = false;
    public bool isBlockDelivered = true;
    private int score = 0;
    public GameObject[] icons;
    public GameObject Block
    {
        set
        {
            if (temp != null)
            {
                temp.SetActive(false);
            }
            temp = value;
            if (temp != null)
            {
                foreach (GameObject item in icons)
                {
                    if (item.name.Equals(temp.name))
                    {
                        temp = item;
                        temp.transform.position = transform.position;
                    }
                }
            }
            temp.SetActive(true);
        }
    }
    private GameObject temp;
    public void AddScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
