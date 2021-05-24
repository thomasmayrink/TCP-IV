using UnityEngine;

public class JogadorModel : Elemento
{
    public int Vidas { get; set; }
    public int NivelPowerUp { get; set; }

    [SerializeField] public PowerUp powerUpNivel1;
    [SerializeField] public PowerUp powerUpNivel2;
    [SerializeField] public PowerUp powerUpNivel3;
}
