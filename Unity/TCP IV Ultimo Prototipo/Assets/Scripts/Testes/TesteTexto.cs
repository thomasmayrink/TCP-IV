using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteTexto : Controller
{
    public Text txtPontos;

    public Slider sliderPowerUp;
    public GameObject btnPowerUp;

    public List<GameObject> vidas;
    private int vidasAux;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Fase.Inicio:
                txtPontos.text = "Pontos: 0";
                sliderPowerUp.value = 0;

                break;

            case Notificacao.Atualizar.AtualizarUI:
                txtPontos.text = "Pontos: " + app.jogadorModel.Pontos;

                vidasAux = app.jogadorModel.Vidas;
                switch (vidasAux)
                {
                    case 0:
                        foreach (GameObject go in vidas)
                        {
                            go.SetActive(false);
                        }
                        break;

                    case 1:
                        vidas[1].gameObject.SetActive(false);
                        break;

                    case 2:
                        vidas[2].gameObject.SetActive(false);
                        break;

                    case 3:
                        foreach(GameObject go in vidas)
                        {
                            go.SetActive(true);
                        }
                        break;
                }

                if (app.jogadorModel.PtsPowerUp <= app.jogadorModel.pontosParaPowerUp1)
                {
                    btnPowerUp.GetComponent<Image>().color = Color.white;
                    btnPowerUp.GetComponent<Button>().interactable = false;
                }
                if (app.jogadorModel.PtsPowerUp >= app.jogadorModel.pontosParaPowerUp1 && app.jogadorModel.PtsPowerUp < app.jogadorModel.pontosParaPowerUp2)
                {
                    btnPowerUp.GetComponent<Image>().color = Color.green;
                    if (!TesteDados.PowerUp3)
                    {
                        btnPowerUp.GetComponent<Button>().interactable = true;
                    }
                }
                if (app.jogadorModel.PtsPowerUp >= app.jogadorModel.pontosParaPowerUp2 && app.jogadorModel.PtsPowerUp < app.jogadorModel.pontosParaPowerUp3)
                {
                    btnPowerUp.GetComponent<Image>().color = Color.yellow;
                    if (!TesteDados.PowerUp3)
                    {
                        btnPowerUp.GetComponent<Button>().interactable = true;
                    }
                }
                if (app.jogadorModel.PtsPowerUp >= app.jogadorModel.pontosParaPowerUp3)
                {
                    btnPowerUp.GetComponent<Image>().color = Color.red;
                    if (!TesteDados.PowerUp3)
                    {
                        btnPowerUp.GetComponent<Button>().interactable = true;
                    }
                }
                sliderPowerUp.value = app.jogadorModel.PtsPowerUp * 0.01f;
                break;

            case Notificacao.Jogador.AcabouPowerUp3:
                if (!(app.jogadorModel.PtsPowerUp <= app.jogadorModel.pontosParaPowerUp1))
                {
                    btnPowerUp.GetComponent<Button>().interactable = true;
                }
                break;
        }
    }
}
