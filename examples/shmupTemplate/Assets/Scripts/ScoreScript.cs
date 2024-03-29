using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;
    public int score;
    public static ScoreScript instance;
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        score = -100;
        UpdateScore();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            UpdateScore();
        }
    }

    public void UpdateScore() {
        score += 100;
        string scoreDisplay = "Score: " + score.ToString();
        scoreText.text = scoreDisplay;
    }
}

