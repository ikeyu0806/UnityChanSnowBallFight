using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "SCORE" + score;
    }
}
