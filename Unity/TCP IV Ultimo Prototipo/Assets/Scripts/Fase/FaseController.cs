using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseController : Controller
{
    private FaseModel model;
    private FaseView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Fase.Inicio:
                model = GetComponent<FaseModel>();
                view = GetComponentInChildren<FaseView>();

                model.JogadorVidas = model.JogadorVidasIniciais;
                model.JogadorPontos = 0;

                view.SetFase(model.BatidasPorSegundo, model.TemposCriarToupeiras, model.TamanhoDaMusica);
                break;

            case Notificacao.Fase.CriarToupeiras:
                //Ver RARIDADE
                if (model.BuracosDisponiveis.Count > 0)
                {
                    view.CriarToupeiras(model.MaxToupeiras, model.BuracosDisponiveis, model.Toupeiras, model.Bpm, model.SomToupeiraSurgindo, model.SomToupeiraAcertou, model.AcertouEfeito);
                }
                else
                {
                    app.DebugFase("Controller model.BuracosDisponiveis.Count: " + model.BuracosDisponiveis.Count);
                }
                break;

            case Notificacao.Fase.Fim:
                app.Notificar(Notificacao.Toupeira.Destruir, model);
                #region APAGAR
                //APAGAR
                GameObject.FindGameObjectWithTag("Luz").GetComponent<Light>().enabled = false;
                Destroy(GameObject.FindGameObjectWithTag("Chao"));
                foreach (GameObject b in model.Buracos)
                {
                    Destroy(b);
                }
                //APAGAR
                #endregion

                app.DebugFase("FIM");
                break;
        }
    }
}
