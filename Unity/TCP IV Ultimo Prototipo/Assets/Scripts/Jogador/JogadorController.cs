using UnityEngine;

public class JogadorController : Controller
{
    JogadorModel model;
    JogadorView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Fase.Inicio:
                model = GetComponent<JogadorModel>();
                view = GetComponent<JogadorView>();

                view.Comecar(model.pontosParaPowerUp1, model.pontosParaPowerUp2, model.pontosParaPowerUp3);
                break;

            case Notificacao.Jogador.PerdeuVida:
                view.Dano(20);
                model.Vidas -= (int)dados[0];
                if (model.Vidas <= 0)
                {
                    model.Vidas = 0;
                    app.Notificar(Notificacao.Fase.Fim, this);
                }
                app.Notificar(Notificacao.Atualizar.AtualizarUI, this);
                break;

            case Notificacao.Jogador.GanhouPontos:
                model.Pontos += (int)dados[0];
                model.PtsPowerUp += (int)dados[1];
                
                switch(model.PtsPowerUp)
                {
                    case int n when n >= 100:
                        model.PtsPowerUp = 100;
                        break;
                }
                view.GanhouPontos(model.PtsPowerUp);

                app.Notificar(Notificacao.Atualizar.AtualizarUI, this);
                break;

            case Notificacao.Jogador.UsouPowerUp:
                switch (model.PtsPowerUp)
                {
                    case int n when n >= model.pontosParaPowerUp1 && n < model.pontosParaPowerUp2:
                        app.Notificar(Notificacao.Jogador.MatarUmaToupeiraAleatoria, this);
                        break;

                    case int n when n >= model.pontosParaPowerUp2 && n < model.pontosParaPowerUp3:
                        app.DebugJogador("Matar todas");
                        app.Notificar(Notificacao.Jogador.MatarTodasToupeiras, this);
                        break;

                    case int n when n >= model.pontosParaPowerUp3:
                        app.DebugJogador("PowerUp 3: " + n);
                        AudioSource audioSource = GetComponent<AudioSource>();
                        audioSource.clip = model.somPowerUp3;
                        audioSource.Play();
                        TesteDados.PowerUp3 = true;
                        app.Notificar(Notificacao.Fase.Parar, this);
                        break;
                }
                model.PtsPowerUp = 0;

                app.Notificar(Notificacao.Atualizar.AtualizarUI, this);
                break;

            case Notificacao.Fase.Fim:
                app.DebugJogador("FaseFim");
                TesteDados.PowerUp3 = false;
                TesteDados.JogoPausado = false;
                TesteDados.PontosUltimaFase = model.Pontos;
                break;
        }
    }
}
