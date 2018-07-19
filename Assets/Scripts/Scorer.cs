using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer {
    private static Scorer instance;
    private int score = 0;
    Text scoreText;
    public static Scorer getInstance()
    {
        if (instance == null)
        {
            instance = new Scorer();
        }
        return instance;
    }

    private Scorer()
    {
        scoreText = (GameObject.Instantiate(Resources.Load("ShowScore")) as GameObject).transform.Find("Score").GetComponent<Text>();
        scoreText.text = "" + score;
    }

    public void AddScore(int level)
    {
        if(level == 0)
        {
            score += 1;
        }else if(level == 1)
        {
            score += 2;
        }else if(level == 3)
        {
            score += 3;
        }

        scoreText.text = "" + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "" + score;
    }
}
