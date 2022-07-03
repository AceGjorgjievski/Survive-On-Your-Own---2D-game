using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreMenagment : MonoBehaviour
{
    public static ScoreMenagment Instance;
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.highScore = PlayerPrefs.GetInt("highscore", 0);
        this.scoreText.text = "SCORE: " + this.score.ToString();
        this.highscoreText.text = "HIGHSCORE: " + this.highScore.ToString();
    }

    public void AddPoint()
    {
        this.score++;
        this.scoreText.text = "SCORE: " + this.score.ToString();

        if(this.highScore < this.score)
        {
            PlayerPrefs.SetInt("highscore", this.score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
