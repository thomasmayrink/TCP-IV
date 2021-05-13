using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToupeiraController : Controller
{
    public override void OnNotificacao(Notificacao evento_caminho, Object alvo)
    {
        switch (evento_caminho)
        {
            case Notificacao.ToupeiraFoiAcertada:
                foreach (Toupeira t in app.toupeiraModel)
                { 
                    if (t.PodeSerAcertada)
                    {
                        Debug.Log("Acertou: " + t);
                        t.FoiAcertada = true;
                        t.Vida--;
                        if (t.Vida <= 0)
                        {
                            app.Notificar(Notificacao.ToupeiraMorreu, this);
                        }
                    }
                }
                break;

            case Notificacao.ToupeiraMorreu:
                foreach (Toupeira t in app.toupeiraModel)
                {
                    t.PodeSerAcertada = false;
                    Debug.Log("DestruirToupeira: " + t);
                }
                break;
        }
    }
}
