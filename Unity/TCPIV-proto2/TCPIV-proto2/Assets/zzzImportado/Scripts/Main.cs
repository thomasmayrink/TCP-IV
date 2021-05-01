using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{    
    public GameObject tiGO;
    public GameObject comecarGO;
    public void ComeçarJogo()
    {
        tiGO.gameObject.SetActive(false);
        comecarGO.gameObject.SetActive(true);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("WhackAMole");
    }
}
