using UnityEngine;
using System.Collections.Generic;

public class Aplicacao : MonoBehaviour
{
    public List<Model> models
    {
        get
        {
            foreach (Model m in FindObjectsOfType<Model>())
            {
                models.Add(m);
            }
            return models;
        }
    }

    public List<View> views
    {
        get
        {
            foreach (View v in FindObjectsOfType<View>())
            {
                views.Add(v);
            }
            return views;
        }
    }

    public List<Controller> controllers
    {
        get
        {
            foreach(Controller c in FindObjectsOfType<Controller>())
            {
                controllers.Add(c);
            }
            return controllers;
        }
    }

   public void Notificar(Notificacao notificacao, Object notificador)
    {
        foreach (Controller c in controllers)
        {
            c.OnNotificacao(notificacao, notificador);
        }
    }
}
