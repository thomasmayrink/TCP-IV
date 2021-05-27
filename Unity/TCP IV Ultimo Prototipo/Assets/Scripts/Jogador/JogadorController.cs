using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorController : Controller
{
    JogadorModel model;
    JogadorView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Jogador.Inicio:
                model = GetComponent<JogadorModel>();
                view = GetComponent<JogadorView>();

                view.Comecar(model.pontosParaPowerUp1, model.pontosParaPowerUp2, model.pontosParaPowerUp3);
                break;

            case Notificacao.Jogador.PerdeuVida:
                model.Vidas -= (int)dados[0];
                if (model.Vidas <= 0)
                {
                    model.Vidas = 0;
                    app.Notificar(Notificacao.Fase.Fim, this);
                }
                app.Notificar(Notificacao.Atualizar.AtualizarUI, this);
                break;

            case Notificacao.Jogador.GanhouPontos:
                model.Pontos += (int)dados[0];
                model.PtsPowerUp += (int)dados[1];
                if (model.PtsPowerUp >= 100)
                {
                    model.PtsPowerUp = 100;
                }
                view.GanhouPontos(model.PtsPowerUp);

                app.Notificar(Notificacao.Atualizar.AtualizarUI, this);
                break;
        }
    }
}
