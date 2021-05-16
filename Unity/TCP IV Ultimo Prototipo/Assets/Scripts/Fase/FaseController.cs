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
                model = GetComponent<FaseModel>();
                view = GetComponentInChildren<FaseView>();

                model.JogadorVidas = model.JogadorVidasIniciais;
                model.JogadorPontos = 0;

                //Fazer função pra lidar com cálculo do intervalo entre instâncias
                model.IntervaloEntreInstancias = model.Bpm / 60 * 2;
                //
                view.timerInstanciasMax = model.IntervaloEntreInstancias;

                switch (model.CondicaoDeFimDeFase)
                {
                    case CondicaoDeFimDeFase.FimDaMusica:
                        view.timerFaseMax = model.TamanhoDaMusica;
                        break;

                    case CondicaoDeFimDeFase.JogadorSemVidas:
                        view.timerFaseMax = 100000000000000;
                        break;
                }
                break;

            case Notificacao.Fase.CriarToupeiras:
                if (model.BuracosDisponiveis.Count > 0)
                {
                    view.CriarToupeiras(model.MaxToupeiras, model.BuracosDisponiveis, model.Toupeiras);
                }
                else
                {
                    app.DebugFase("Controller model.BuracosDisponiveis.Count: " + model.BuracosDisponiveis.Count);
                }
                break;

            case Notificacao.Fase.Fim:
                //Ir para tela de game over
                app.DebugFase("Fase Fim");
                app.Notificar(Notificacao.Toupeira.Destruir, model);

                break;
        }
    }
}
