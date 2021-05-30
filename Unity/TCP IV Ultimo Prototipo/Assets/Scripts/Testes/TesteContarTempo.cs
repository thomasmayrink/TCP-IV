using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteContarTempo : Controller
{
    [SerializeField] public Text[] txtTimer;

    private bool rodando;

    private float timer;
    float minutos, segundos;

    void Start()
    {
        timer = FindObjectOfType<FaseModel>().TimerFaseMax + 1f;
        rodando = true;
    }

    void Update()
    {
        if (rodando)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                rodando = false;
                timer = 0;
                app.Notificar(Notificacao.Fase.Fim, this);
            }
            minutos = Mathf.FloorToInt(timer / 60);
            segundos = Mathf.FloorToInt(timer % 60);

            if (minutos < 10)
            {
                if (segundos < 10)
                {
                    foreach (Text t in txtTimer)
                    {
                        t.text = "0" + minutos + ":0" + segundos;
                    }
                }
                else
                {
                    foreach (Text t in txtTimer)
                    {
                        t.text = "0" + minutos + ":" + segundos;
                    }
                }
            }
            else
            {
                if (segundos < 10)
                {
                    foreach (Text t in txtTimer)
                    {
                        t.text = "0" + minutos + ":0" + segundos;
                    }
                }
                else
                {
                    foreach (Text t in txtTimer)
                    {
                        t.text = minutos + ":" + segundos;
                    }
                }
            }
        }
    }

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Jogador.GanhouPontos:
                timer += (int)dados[2];
                break;
        }
    }
}
