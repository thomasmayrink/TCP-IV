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

                //view.SetFase(model.BatidasPorSegundo, model.TemposCriarToupeiras, model.TamanhoDaMusica);

                view.SetFase(model.BatidasPorSegundo, model.TemposCriarToupeiras);
                break;

            case Notificacao.Fase.CriarToupeiras:
                if (model.BuracosDisponiveis.Count > 0)
                {
                    view.CriarToupeiras(model.MaxToupeiras, model.MaxArmadilhas, model.BuracosDisponiveis, model.Toupeiras, model.Armadilhas, model.Bpm, model.SomToupeiraSurgindo, model.SomToupeiraAcertou, model.AcertouEfeito);
                }
                break;

            case Notificacao.Fase.CriarArmadilhas:
                if (model.BuracosDisponiveis.Count > 0)
                {
                    //view.CriarArmadilhas(model.MaxArmadilhas, model.BuracosDisponiveis, model.Armadilhas, model.)
                }
                break;

            case Notificacao.Fase.Fim:
                app.Notificar(Notificacao.Toupeira.Destruir, model);

                #region APAGAR
                GameObject.FindGameObjectWithTag("Luz").GetComponent<Light>().enabled = false;
                Destroy(GameObject.FindGameObjectWithTag("Chao"));
                foreach (GameObject b in model.Buracos)
                {
                    Destroy(b);
                }
                #endregion

                app.DebugFase("FIM");
                break;
        }
    }
}
