using UnityEngine;
using UnityEngine.SceneManagement;

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
                    view.CriarToupeiras(model.MaxToupeiras, 
                                        model.MaxArmadilhas,
                                        model.BuracosDisponiveis,
                                        model.Toupeiras,
                                        model.Armadilhas, 
                                        model.Bpm, 
                                        model.SonsSurgindo[Random.Range(0, model.SonsSurgindo.Length)],
                                        model.SonsAcertou[Random.Range(0, model.SonsAcertou.Length)], 
                                        model.AcertouEfeito);
                }
                break;

            case Notificacao.Fase.CriarArmadilhas:
                if (model.BuracosDisponiveis.Count > 0)
                {
                    //view.CriarArmadilhas(model.MaxArmadilhas, model.BuracosDisponiveis, model.Armadilhas, model.)
                }
                break;

            case Notificacao.Fase.AumentarDificuldade:
                model.Bpm *= 1.25f;
                if (model.Bpm > model.BpmMax)
                {
                    model.Bpm = model.BpmMax;
                }
                break;

            case Notificacao.Fase.Fim:
                SceneManager.LoadScene("GabrielGameOver");

                /*
                app.Notificar(Notificacao.Toupeira.Destruir, model);


                #region APAGAR
                foreach (GameObject b in model.Buracos)
                {
                    Destroy(b);
                }
                Destroy(app.jogadorModel.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Chao"));
                app.luz.enabled = false;
                app.musicaSource.enabled = false;


                #endregion
                */
                app.DebugFase("FIM");
                break;
        }
    }
}
