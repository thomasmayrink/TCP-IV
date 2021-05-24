public static class FabricaPowerUp
{
    public static void Criar(PowerUpModel model, PowerUp powerUp)
    {
        model.Nivel = powerUp.nivel;
        model.TipoDePowerUp = powerUp.tipoDePowerUp;
    }
}