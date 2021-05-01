using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{   
    static int score;
    public static int scoreToReach;
    
    public static void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
        UIManager.instance.UpdateUI(score,scoreToReach);
    }

    public static int ReadScore()
    {
        return score;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
