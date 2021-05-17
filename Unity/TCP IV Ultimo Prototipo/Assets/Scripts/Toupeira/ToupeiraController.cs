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
                if (view.EstadoAtual == ToupeiraView.Estado.Surgindo)
                {
                    if (alvo == view)
                    {
                        view.SetTempoNaTela(model.TemposNaTela * app.faseModel.BatidasPorSegundo);
                        view.TocarSom(model.SomAoSurgir);
                        view.Surgir(model.Velocidade, model.Buraco.transform.position.y + 1.55f);
                    }
                }
                break;

            case Notificacao.Toupeira.Idle:
                if (alvo == view)
                {
                    model.PodeSerAcertada = true;
                    view.Idle(model.DancasId, model.Comportamento);
                }
                break;

            case Notificacao.Toupeira.FoiAcertada:
                if (alvo == view && model.PodeSerAcertada)
                {
                    view.TocarSom(model.SomPancada);
                    model.Vida--;

                    if (model.Vida <= 0)
                    {
                        model.PodeSerAcertada = false;
                        //model.EstaDescendo = true;
                        view.Acertar("Matou", true);
                    }
                    else
                    {
                        model.PodeSerAcertada = false;
                        view.Acertar("Acertou", true);
                    }
                }
                break;

            case Notificacao.Toupeira.Descendo:
                if (alvo == view)
                {
                    model.PodeSerAcertada = false;
                    //model.EstaDescendo = true;
                }
                break;

            case Notificacao.Toupeira.Destruir:
                if (alvo == view)
                {
                    model.Buraco.GetComponent<Buraco>().Desocupar();
                    Destroy(gameObject);
                }
                if (alvo == app.faseModel)
                {
                    app.DebugToupeira("faseModel Destruir");
                    Destroy(gameObject);
                }
                break;
        }
    }
}