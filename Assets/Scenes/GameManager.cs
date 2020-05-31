using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;
    public int lives;
    public Text scoreText;
    public Text livesText;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 100;
        //scoreText.text = score.ToString();
        //livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives()
    {
        lives = lives - 1;
        livesText.text = lives.ToString();
    }

    public void UpdateScores()
    {
        score = score + 100;
        scoreText.text = score.ToString();
    }


}
