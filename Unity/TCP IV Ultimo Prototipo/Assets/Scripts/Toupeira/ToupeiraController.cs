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
                    model.Vida--;
                    if (model.Vida == 0)
                    {
                        view.Acertar("Matou", model.acertouEfeito);
                        app.Notificar(Notificacao.Jogador.GanhouPontos, this, model.Pontos, model.PontosPowerUp);
                    }
                    else
                    {
                        view.Acertar("Acertou", model.acertouEfeito);
                    }
                    view.TocarSom(model.SomPancada);
                }
                break;

            case Notificacao.Toupeira.Desceu:
                if (alvo == view)
                {
                    model.Buraco.GetComponent<Buraco>().EstaOcupado = false;
                    Destroy(gameObject);
                }
                break;
        }
    }
}
