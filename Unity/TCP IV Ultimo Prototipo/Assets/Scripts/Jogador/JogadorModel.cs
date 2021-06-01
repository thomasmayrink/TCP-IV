using UnityEngine;
using UnityEngine.UI;

public class JogadorModel : Elemento
{
    public int Vidas { get; set; }
    public int Pontos { get; set; }
    public int PtsPowerUp { get; set; }
    [SerializeField][Range(0,100)] public int pontosParaPowerUp1;
    [SerializeField] public GameObject efeitoPowerUp1;
    [SerializeField] public AudioClip somPowerUp1;
    [SerializeField] [Range(0, 100)] public int pontosParaPowerUp2;
    [SerializeField] public GameObject efeitoPowerUp2;
    [SerializeField] public AudioClip somPowerUp2;
    [SerializeField] [Range(0, 100)] public int pontosParaPowerUp3;
    [SerializeField] public AudioClip somPowerUp3;

    /*
    [SerializeField] public PowerUp powerUpNivel1;

    [SerializeField] public PowerUp powerUpNivel2;

    [SerializeField] public PowerUp powerUpNivel3;
    */
}
