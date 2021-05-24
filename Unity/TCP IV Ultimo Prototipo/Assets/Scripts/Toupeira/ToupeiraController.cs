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
                    model.PodeSerAcertada = true;
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
                break;

            case Notificacao.Toupeira.Descendo:
                break;

            case Notificacao.Toupeira.Destruir:
                if (alvo == view)
                {
                    view.gameObject.GetComponent<Collider>().enabled = false;
                    model.Buraco.GetComponent<Buraco>().EstaOcupado = false;
                    Destroy(gameObject);
                }
                break;
        }
    }
}
