using UnityEngine;

public class ToupeiraController : Controller
{
    private ToupeiraModel model;
    private ToupeiraView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Toupeira.Subindo:
                model = GetComponent<ToupeiraModel>();
                view = GetComponentInChildren<ToupeiraView>();
                
                model.PodeSerAcertada = false;

                view.Subir(model.Velocidade, model.Buraco.transform.position.y + 1.55f);
                break;

            case Notificacao.Toupeira.Idle:
                model.PodeSerAcertada = true;

                switch(model.Comportamento)
                {
                    case Comportamento.Doido:
                        break;

                    case Comportamento.Fofo:
                        break;

                    case Comportamento.Lider:
                        break;

                    case Comportamento.PoucosAmigos:
                        break;
                }

                break;

            case Notificacao.Toupeira.FoiAcertada:
                if (view == alvo && model.PodeSerAcertada)
                {
                    model.Vida--;
                    if (model.Vida <= 0)
                    {
                        model.PodeSerAcertada = false;
                        view.Descer();
                    }
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
