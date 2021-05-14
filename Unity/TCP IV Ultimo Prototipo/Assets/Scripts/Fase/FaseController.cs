using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseController : Controller
{
    private FaseModel model;
    private FaseView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch(evento_caminho)
        {
            case Notificacao.Fase.Inicio:
                //Debug.Log(Notificacao.Fase.Inicio);

                model = GetComponent<FaseModel>();
                view = GetComponentInChildren<FaseView>();

                model.JogadorVidas = model.JogadorVidasIniciais;
                model.JogadorPontos = 0;
                //Fazer função pra lidar com cálculo do intervalo entre instâncias
                model.IntervaloEntreInstancias = model.Bpm / 60;
                view.timerMax = model.IntervaloEntreInstancias;
                app.DebugController("faseView.timerMax: " + view.timerMax);
                break;

            case Notificacao.Fase.CriarToupeiras:
                //Debug.Log(Notificacao.Fase.CriarToupeiras);
                if (model.BuracosDisponiveis.Count > 0)
                {
                    view.CriarToupeiras(model.BuracosDisponiveis, model.Toupeiras);
                }
                else
                {
                    app.DebugController("faseModel.BuracosDisponiveis.Count: " + model.BuracosDisponiveis.Count);
                }
                break;

            case Notificacao.Fase.Fim:
                //Ir para tela de game over
                Debug.Log("Fase Fim");
                break;
        }
    }
}
