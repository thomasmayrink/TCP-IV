using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text scoreText;
    public Text timeText;

    void Awake()
    {
        instance = this;        
        UpdateTime(1,0);
    }
    
    public void UpdateTime(int mins, int secs)
    {
        timeText.text = mins.ToString("D2") + ":" + secs.ToString("D2");
    }

    public void UpdateUI(int score, int scoreToReach)
    {
        scoreText.text = "Score: " + score + "/" + scoreToReach; 

    }

}
