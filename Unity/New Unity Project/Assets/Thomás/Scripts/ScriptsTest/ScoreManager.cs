using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int score;

    public static void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
        UIManager.instance.UpdateUI();
    }

    public static int ReadScore()
    {
        return score;
    }
}
