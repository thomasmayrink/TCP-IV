using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteTexto : Controller
{
    public Text txtPontos;
    public Text txtVidas;
    int pontos;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Jogador.GanhouPontos:
                pontos += (int)dados[0];
                txtPontos.text = "Pontos: " + pontos;
                break;

            case Notificacao.Jogador.PerdeuVida:

                break;
        }
    }
}
