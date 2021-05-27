using UnityEngine;

public class JogadorModel : Elemento
{
    public int Vidas { get; set; }
    public int Pontos { get; set; }
    public int PtsPowerUp { get; set; }

    [SerializeField][Range(0,100)] public int pontosParaPowerUp1;
    [SerializeField] public PowerUp powerUpNivel1;

    [SerializeField][Range(0, 100)] public int pontosParaPowerUp2;
    [SerializeField] public PowerUp powerUpNivel2;

    [SerializeField][Range(0, 100)] public int pontosParaPowerUp3;
    [SerializeField] public PowerUp powerUpNivel3;
}
