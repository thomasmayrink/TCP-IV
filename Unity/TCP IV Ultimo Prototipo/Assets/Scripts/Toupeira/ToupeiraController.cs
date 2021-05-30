using UnityEngine;

public class ToupeiraController : Controller
{
    private ToupeiraModel model;
    private ToupeiraView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Toupeira.Surgindo:
                model = GetComponent<ToupeiraModel>();
                view = GetComponentInChildren<ToupeiraView>();
                if (alvo == view)
                {
                    model.Descendo = false;
                    view.TocarSom(model.SomAoSurgir);
                    view.Surgir(model.Velocidade, model.Buraco.transform.position.y + 1.55f);
                }
                break;

            case Notificacao.Toupeira.Idle:
                if (alvo == view)
                {
                    view.Idle(model.BpmFase, model.DancasId, model.Comportamento, model.TemposNaTela);
                }
                break;

            case Notificacao.Toupeira.FoiAcertada:
                if (alvo == view)
                {
                    if (model.Dano > 0)
                    {
                        view.TocarSom(model.SomDano);
                        app.Notificar(Notificacao.Jogador.PerdeuVida, this, model.Dano);
                    }
                    else
                    {
                        view.TocarSom(model.SomPancada);
                    }
                    model.Vida--;
                    if (model.Vida <= 0)
                    {
                        view.Acertou("Matou", model.AcertouEfeito);
                        model.Descendo = true;
                        app.Notificar(Notificacao.Jogador.GanhouPontos, this, model.Pontos, model.PontosPowerUp, model.PontosTimer);
                    }
                    else
                    {
                        view.Acertou("Acertou", model.AcertouEfeito);
                    }
                }
                break;

            case Notificacao.Toupeira.MatarUma:
                if (alvo == view)
                {
                    if (model.Dano > 0)
                    {
                        view.TocarSom(model.SomDano);
                        app.Notificar(Notificacao.Jogador.PerdeuVida, this, model.Dano);
                    }
                    else
                    {
                        view.TocarSom(app.jogadorModel.somPowerUp1);
                    }
                    model.Vida = 0;

                    view.Acertou("Matou", app.jogadorModel.efeitoPowerUp1);
                    model.Descendo = true;
                    app.Notificar(Notificacao.Jogador.GanhouPontos, this, model.Pontos, model.PontosPowerUp);
                }
                break;

            case Notificacao.Toupeira.MatarTodas:
                if (alvo == view)
                {
                    if (model.Dano > 0)
                    {
                        view.TocarSom(model.SomDano);
                        app.Notificar(Notificacao.Jogador.PerdeuVida, this, model.Dano);
                    }
                    else
                    {
                        view.TocarSom(app.jogadorModel.somPowerUp2);
                    }
                    model.Vida = 0;

                    view.Acertou("Matou", app.jogadorModel.efeitoPowerUp1);
                    model.Descendo = true;
                    app.Notificar(Notificacao.Jogador.GanhouPontos, this, model.Pontos, model.PontosPowerUp);
                }
                break;

            case Notificacao.Toupeira.Desceu:
                if (alvo == view)
                {
                    /*
                    if (model.Vida > 0)
                    {
                        view.TocarSom(model.SomFugiu);
                    }
                    */
                    model.Buraco.GetComponent<Buraco>().EstaOcupado = false;
                    Destroy(gameObject, 1f);
                }
                break;
                /*
            case Notificacao.Fase.Parar:
                view.Rodando(false);
                break;

            case Notificacao.Fase.Voltar:
                view.Rodando(true);
                break;
                */
        }
    }
}
