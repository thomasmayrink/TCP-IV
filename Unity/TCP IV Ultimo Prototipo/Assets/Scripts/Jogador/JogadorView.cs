using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorView : Elemento
{
    private Estados estado;
    //private int pontosPowerUp;
    private int limitePowerUp1, limitePowerUp2, limitePowerUp3;

    private int nivelPowerUp;

    void Start()
    {
        estado = Estados.Inicio;
    }

    void Update()
    {
        switch (estado)
        {
            case Estados.Inicio:
                app.Notificar(Notificacao.Jogador.Inicio, this);
                break;

            case Estados.Rodando:
                switch (nivelPowerUp)
                {
                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;
                }
                break;
        }
    }

    public void Comecar(int powerUp1, int powerUp2, int powerUp3)
    {
        limitePowerUp1 = powerUp1;
        limitePowerUp2 = powerUp2;
        limitePowerUp3 = powerUp3;

        estado = Estados.Rodando;
    }

    public void GanhouPontos(int pontosPowerUp)
    {
     //   this.pontosPowerUp += pontosPowerUp;

        if (pontosPowerUp >= limitePowerUp3)
        {
            nivelPowerUp = 3;
        }
        else if (pontosPowerUp >= limitePowerUp2)
        {
            nivelPowerUp = 2;
        }
        else if(pontosPowerUp >= limitePowerUp1)
        {
            nivelPowerUp = 1;
        }
    }

    private enum Estados
    {
        Inicio,
        Rodando
    }
}
