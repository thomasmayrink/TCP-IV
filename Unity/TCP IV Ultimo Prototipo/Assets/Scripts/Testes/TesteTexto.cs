using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteTexto : Controller
{
    public Text txtPontos, txtVidas, txtPtsPowerUp;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Fase.Inicio:
                txtPontos.text = "Pontos: 0";
                txtVidas.text = "Vidas: " + app.jogadorModel.Vidas;
                txtPtsPowerUp.text = "Pontos Power Up: 0";
                break;

            case Notificacao.Atualizar.AtualizarUI:
                txtPontos.text = "Pontos: " + app.jogadorModel.Pontos;
                txtVidas.text = "Vidas: " + app.jogadorModel.Vidas;
                txtPtsPowerUp.text = "Pontos Power Up: " + app.jogadorModel.PtsPowerUp;
                break;

                /*
            case Notificacao.Jogador.GanhouPontos:
                txtPontos.text = "Pontos: " + app.jogadorModel.Pontos;
                txtPtsPowerUp.text = "Pontos Power Up: " + app.jogadorModel.PtsPowerUp;
                break;

            case Notificacao.Jogador.PerdeuVida:
                txtVidas.text = "Vidas: " + app.jogadorModel.Vidas;
                break;

                */
        }
    }
}
