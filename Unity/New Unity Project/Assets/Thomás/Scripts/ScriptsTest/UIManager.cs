using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    void Awake()
    {
        instance = this;
    }
    public Text scoreText;

    public void UpdateUI()
    {
        scoreText.text = "Score: " + ScoreManager.ReadScore(); 

    }

}
