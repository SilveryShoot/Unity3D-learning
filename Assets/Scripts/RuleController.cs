using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleController : MonoBehaviour {
    private int level = 0;
    private Color[] color = { Color.blue, Color.red, Color.green };
    private float[] speed = { 20f, 30f, 40f };
    private float[] scale = { 1.2f, 1.0f, 0.8f };
    private Text levelText;

    private void Awake()
    {
        UFOFactory.getInstance().ruleController = this;
        levelText = (GameObject.Instantiate(Resources.Load("ShowLevel")) as GameObject).transform.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level: " + level;
    }

    public void IncreaseLevelByScore(int score)
    {
        if(score > 20)
        {
            level = 1;
            levelText.text = "Level: " + level;
        }
        if(score > 60)
        {
            level = 2;
            levelText.text = "Level: " + level;
        }
    }

    public void Reset()
    {
        level = 0;
        levelText.text = "Level: " + level;
    }

    public int GetLevel()
    {
        return level;
    }

    public Color GetColor()
    {
        return color[level];
    }

    public float GetSpeed()
    {
        return speed[level];
    }

    public float GetScale()
    {
        return scale[level];
    }
}
