using UnityEngine;

public class ToupeiraController : Controller
{
    public ToupeiraView view { get; set; }
    public ToupeiraModel model { get; set; }

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Toupeira.Subindo:
                //view.Subir(model.Velocidade, model.PosicaoInicial.y + 1.5f))
                break;

            case Notificacao.Toupeira.FoiAcertada:
                /*
                if (model.PodeSerAcertada) 
                {
                    model.Vida--;
                }
                if (model.Vida <= 0)
                {
                    app.Notificar(Notificacao.Toupeira.Destruir, this);
                }
                */
                Debug.Log(Notificacao.Toupeira.FoiAcertada);
                break;

            case Notificacao.Toupeira.Destruir:
                //Destroy(gameObject);
                Debug.Log(Notificacao.Toupeira.Destruir);
                break;
        }
    }
}
