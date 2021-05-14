using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseController : Controller
{
    private FaseModel model;
    private FaseView view;

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch(evento_caminho)
        {
            case Notificacao.Fase.Inicio:
                //model = GetComponent<FaseModel>();
                //view = GetComponentInChildren<FaseView>();
                Debug.Log("Fase Inicio");
                break;

            case Notificacao.Fase.CriarToupeiras:
                //view.CriarToupeira(model.Toupeiras, model.Buracos.Length, model.QtdBuracosOcupados, (ToupeiraModel)dados[0], (Vector3)dados[1]);
                Debug.Log("Criar Toupeiras");
                break;

            case Notificacao.Fase.Fim:
                //Ir para tela de game over
                Debug.Log("Fase Fim");
                break;
        }
    }
}
