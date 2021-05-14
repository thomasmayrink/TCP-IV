using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplicacao : MonoBehaviour
{
    public void Notificar(string evento_caminho, Object alvo, params object[] dados)
    {
        Controller[] controllers = Controllers;
        foreach(Controller c in controllers)
        {
            c.OnNotificacao(evento_caminho, alvo, dados);
        }
    }

    private Controller[] Controllers 
    {
        get
        {
            return GameObject.FindObjectsOfType<Controller>();
        }
    }
}
