using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int playtime = 60;  
    int seconds, minutes;

    //
    static int curLevel = 1;
    int baseScore = 50;
    int scoreToReach;
    void Start()
    {   
        scoreToReach = curLevel * (baseScore * curLevel);
        ScoreManager.scoreToReach = scoreToReach;
        UIManager.instance.UpdateUI(0, scoreToReach);
        StartCoroutine("PlayTimer");
    }

    IEnumerator PlayTimer()
    {
        while(playtime > 0)
        {
            yield return new WaitForSeconds(1);
            playtime--;
            seconds = playtime % 60;
            minutes = playtime / 60 % 60;
            //UPDATE UI
            UIManager.instance.UpdateTime(minutes, seconds);
        }
        Debug.Log("Timer has ended");
        CheckForWin();
    }

    void CheckForWin()
    {   
        if(ScoreManager.ReadScore() >= scoreToReach)
        {
            Debug.Log("You won the level");
            curLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else 
        {
            Debug.Log("Game Over");
        }

    }
}
