using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TIMER
    int playTime = 60;
    int seconds, minutes;

    //
    public static int curLevel = 1;
    int baseScore = 50;
    int scoreToReach;


    void Start()
    {
        scoreToReach = curLevel * (baseScore * curLevel);
        ScoreManager.scoreToReach = scoreToReach;
        UIManager.instance.UpdateUI(ScoreManager.ReadScore(), scoreToReach);
        StartCoroutine("PlayTimer");
    }

    IEnumerator PlayTimer()
    {
        while(playTime > 0)
        {
        yield return new WaitForSeconds(1);
        playTime--;
        seconds = playTime % 60;
        minutes = playTime / 60 % 60;
        //UPDATE UI
        UIManager.instance.UpdateTime(minutes,seconds);        
        }
    
        Debug.Log("Timer has ended");
        // WIN CONDITION
        CheckForWin();

    }

    void CheckForWin()
    {
        if(ScoreManager.ReadScore() >=scoreToReach)
        {
            Debug.Log("You won the level");
            curLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //GameOver
            Debug.Log("Game Over");
        }
    }

}
