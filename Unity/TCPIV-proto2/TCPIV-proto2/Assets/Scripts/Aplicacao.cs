using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplicacao : MonoBehaviour
{ 
    public Fase faseModel { get; set; }
    public FaseController faseController { get; set; }

    public Toupeira[] toupeiraModel { get; set; }
    public ToupeiraView[] toupeiraView { get; set; }
    public ToupeiraController[] toupeiraController { get; set; }

    //public Buraco buraco { get; set; }

    public void Notificar(Notificacao evento_caminho, Object alvo)
    {
        Controller[] controllers = GetControllers();
        foreach(Controller c in controllers)
        {
            c.OnNotificacao(evento_caminho, alvo);
        }
    }

    private Controller[] GetControllers()
    {
        return GameObject.FindObjectsOfType<Controller>();
    }
}
