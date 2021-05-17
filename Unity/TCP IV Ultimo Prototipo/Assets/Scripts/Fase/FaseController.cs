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

                model.BatidasPorSegundo = model.Bpm / 60f;
                view.batidasPorSegundo = model.BatidasPorSegundo;
                view.timerInstanciasMax = view.batidasPorSegundo;

                view.tempos = model.TemposCriarToupeiras;

                //app.DebugFase("view.batidasPorSegundo = " + view.batidasPorSegundo);
                view.temposPrimeiraInstancia = model.TemposAtePrimeiraInstanciacao * model.BatidasPorSegundo;

                switch (model.CondicaoDeFimDeFase)
                {
                    case CondicaoDeFimDeFase.FimDaMusica:
                        view.timerFaseMax = model.TamanhoDaMusica;
                        break;

                    case CondicaoDeFimDeFase.JogadorSemVidas:
                        view.timerFaseMax = 0;
                        break;
                }
                break;

            case Notificacao.Fase.CriarToupeiras:
                //Ver RARIDADE

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

                #region APAGAR
                //APAGAR
                GameObject.FindGameObjectWithTag("Luz").GetComponent<Light>().enabled = false;
                Destroy(GameObject.FindGameObjectWithTag("Chao"));
                foreach(GameObject b in model.Buracos)
                {
                    Destroy(b);
                }
                //APAGAR
                #endregion

                break;
        }
    }
}
