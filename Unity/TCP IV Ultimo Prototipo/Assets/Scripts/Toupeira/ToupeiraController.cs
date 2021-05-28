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
                    if (model.Vida == 0)
                    {
                        view.Acertou("Matou", model.AcertouEfeito);
                        app.Notificar(Notificacao.Jogador.GanhouPontos, this, model.Pontos, model.PontosPowerUp);
                    }
                    else
                    {
                        view.Acertou("Acertou", model.AcertouEfeito);
                    }
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
        }
    }
}
