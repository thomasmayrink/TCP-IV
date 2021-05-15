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

                model.PodeSerAcertada = true;
                model.FoiAcertada = false;

                //view.Subir(model.Velocidade, model.PosicaoInicial.y + 1.5f))

                //Debug.Log("Subindo model.FoiAcertada: " + model.FoiAcertada);
                break;

            case Notificacao.Toupeira.Idle:
                model.PodeSerAcertada = true;

                break;

            case Notificacao.Toupeira.FoiAcertada:
                app.DebugToupeira("Notificacao Foi Acertada: " + alvo);
                if (model.PodeSerAcertada) 
                {
                    app.DebugToupeira("Controller model.Vida: " + model.Vida);
                    model.Vida--;
                    model.PodeSerAcertada = false;
                    app.DebugToupeira("Controller foi acertada");
                }
                else
                /*
                if (model.Vida <= 0)
                {
                    app.Notificar(Notificacao.Toupeira.Destruir, this);
                }
                */
                app.DebugToupeira("Controller não foi acertada");
                
                break;

            case Notificacao.Toupeira.Destruir:
                //Destroy(gameObject);
                Debug.Log(Notificacao.Toupeira.Destruir);
                break;
        }
    }
}
