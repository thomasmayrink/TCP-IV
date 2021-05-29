using UnityEngine;

public class ArmadilhaController : Controller
{
    private ArmadilhaModel model;
    private ArmadilhaView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Armadilha.Surgindo:
                model = GetComponent<ArmadilhaModel>();
                view = GetComponentInChildren<ArmadilhaView>();
                if (alvo == view)
                {
                    view.TocarSom(model.SomAoSurgir);
                    view.Surgir(model.Velocidade, model.Buraco.transform.position.y + 1.55f);
                }
                break;

            case Notificacao.Armadilha.Idle:
                if (alvo == view)
                {
                    view.Idle(model.TemposNaTela);
                }
                break;

            case Notificacao.Armadilha.FoiAcertada:
                if (alvo == view)
                {
                    model.Vida--;
                    if (model.Vida <= 0)
                    {
                        view.TocarSom(model.SomDano);
                        app.Notificar(Notificacao.Jogador.PerdeuVida, this, model.Dano);
                        view.Acertou(model.AcertouEfeito);
                        view.Descer();
                    }
                }
                break;

            case Notificacao.Armadilha.Desceu:
                if (alvo == view)
                {
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
