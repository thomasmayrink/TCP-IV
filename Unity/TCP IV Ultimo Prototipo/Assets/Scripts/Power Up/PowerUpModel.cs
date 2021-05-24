public class PowerUpModel : Elemento
{
    public int Nivel { get; set; }
    public PowerUpTipo TipoDePowerUp { get; set; }
}

public enum PowerUpTipo
{
    AcertarAleatoriamente,
    AcertarTudo,
    PararTempo
}
