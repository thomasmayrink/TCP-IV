using UnityEngine;
using UnityEngine.UI;
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

                view.SetFase(model.BatidasPorSegundo, model.TemposCriar, model.Proporcao);
                break;

            case Notificacao.Fase.CriarToupeiras:
                if (model.BuracosDisponiveis.Count > 0)
                {
                    view.CriarToupeiras(model.MaxToupeiras, 
                                        model.BuracosDisponiveis,
                                        model.Toupeiras,
                                        model.Bpm, 
                                        model.SonsSurgindo[Random.Range(0, model.SonsSurgindo.Length)],
                                        model.SonsAcertou[Random.Range(0, model.SonsAcertou.Length)], 
                                        model.SonsDano[Random.Range(0, model.SonsDano.Length)],
                                        //model.SonsFugiu[Random.Range(0, model.SonsFugiu.Length)],
                                        model.AcertouEfeito);
                }
                else
                {
                    app.DebugFase("model.BuracosDisponiveis.Count == " + model.BuracosDisponiveis.Count);
                }
                break;
                
            case Notificacao.Fase.CriarArmadilhas:
                if (model.BuracosDisponiveis.Count > 0)
                {
                    view.CriarArmadilhas(model.MaxArmadilhas,
                                         model.BuracosDisponiveis,
                                         model.Armadilhas,
                                         model.Bpm,
                                         model.SonsSurgindo[Random.Range(0, model.SonsSurgindo.Length)],
                                         model.SonsAcertou[Random.Range(0, model.SonsAcertou.Length)],
                                         model.SonsDano[Random.Range(0, model.SonsDano.Length)],
                                         model.AcertouEfeito);
                }
                else
                {
                    app.DebugFase("model.BuracosDisponiveis.Count == " + model.BuracosDisponiveis.Count);
                }
                break;
                
            case Notificacao.Fase.AumentarDificuldade:
                model.Bpm *= 1.25f;
                if (model.Bpm > model.BpmMax)
                {
                    model.Bpm = model.BpmMax;
                }
                break;

            case Notificacao.Jogador.MatarUmaToupeiraAleatoria:
                try
                {
                    int r = Random.Range(0, TesteDados.Toupeiras.Length);
                    while (TesteDados.Toupeiras[r].GetComponent<ToupeiraModel>().Descendo)
                    {
                        r = Random.Range(0, TesteDados.Toupeiras.Length);
                    }
                    app.Notificar(Notificacao.Toupeira.MatarUma, TesteDados.Toupeiras[r].GetComponentInChildren<ToupeiraView>());
                } catch { }

                break;

            case Notificacao.Jogador.MatarTodasToupeiras:
                for (int i = 0; i < TesteDados.Toupeiras.Length; i++)
                {
                    app.Notificar(Notificacao.Toupeira.MatarTodas, TesteDados.Toupeiras[i].GetComponentInChildren<ToupeiraView>());
                }
                break;

/*            case Notificacao.Jogador.MatarTodasToupeiras:
                try
                {
                    app.DebugFase("MatarTodas");
                    for (int i = 0; i < TesteDados.Toupeiras.Length; i++)
                    {
                        app.Notificar(Notificacao.Toupeira.MatarTodas, TesteDados.Toupeiras[i].GetComponentInChildren<ToupeiraView>());
                    }
                } catch
                {
                    app.DebugFase("MatarTodas catch");
                }

                break;
*/

            case Notificacao.Fase.Parar:
                app.DebugFase("Controller Parar");
                view.Parar();
                break;
                
            case Notificacao.Fase.Voltar:
                app.DebugFase("Controller Voltar");
                view.Voltar();
                break;

            case Notificacao.Fase.Fim:
                app.DebugFase("Fim");
                #region MELHORAR
                /*
                app.musicaSource.Stop();
                foreach(GameObject go in model.BuracosOcupados)
                {
                    try
                    {
                        Destroy(go.GetComponent<Buraco>().Toupeira);
                    }
                    catch
                    {
                        Destroy(go.GetComponent<Buraco>().Armadilha);
                    }
                }
                foreach(GameObject go in model.Buracos)
                {
                    Destroy(go);
                }
                */
                Destroy(GameObject.Find("Luzes"));
              
                /*
                foreach(Text t in TesteContarTempo.TxtTimer)
                {
                    t.text = "00:00";
                }
                */
                FindObjectOfType<TesteMenu>().GameOver();
                #endregion

                break;
        }
    }
}
