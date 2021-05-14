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
                //view.Subir(model.Velocidade, model.PosicaoInicial.y + 1.5f))

                //Debug.Log("Subindo model.FoiAcertada: " + model.FoiAcertada);

                break;

            case Notificacao.Toupeira.FoiAcertada:
                if (model.PodeSerAcertada) 
                {
                    app.DebugController("toupeira model.Vida: " + model.Vida);
                    model.Vida--;
                    model.PodeSerAcertada = false;
                    app.DebugController("toupeira foi acertada");
                }
                /*
                if (model.Vida <= 0)
                {
                    app.Notificar(Notificacao.Toupeira.Destruir, this);
                }
                */
                app.DebugController("toupeira não foi acertada");
                
                break;

            case Notificacao.Toupeira.Destruir:
                //Destroy(gameObject);
                Debug.Log(Notificacao.Toupeira.Destruir);
                break;
        }
    }
}
