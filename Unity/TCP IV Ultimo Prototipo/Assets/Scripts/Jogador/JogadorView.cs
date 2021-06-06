using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogadorView : Elemento
{
    private Estados estado;

    private int limitePowerUp1, limitePowerUp2, limitePowerUp3;

    private int nivelPowerUp;

    private bool efeitoDano;
    private float timer;

    void Start()
    {
        efeitoDano = false;
        timer = 0;
        estado = Estados.Inicio;
    }

    void Update()
    {
        if (efeitoDano)
        {
            timer += Time.deltaTime;
        }

        switch (estado)
        {
            case Estados.Inicio:
                app.Notificar(Notificacao.Fase.Inicio, this);
                break;

            case Estados.Rodando:
                if (timer >= 0.05f)
                {
                    Dano(0);
                    efeitoDano = false;
                    timer = 0;
                }

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
    public void UsouPowerUp()
    {
        app.Notificar(Notificacao.Jogador.UsouPowerUp, this);
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

    public void Dano(int intensity)
    {
        efeitoDano = true;
        try
        {
            app.luz.intensity = intensity;
        }
        catch
        {

        }
    }

    private enum Estados
    {
        Inicio,
        Rodando
    }
}
