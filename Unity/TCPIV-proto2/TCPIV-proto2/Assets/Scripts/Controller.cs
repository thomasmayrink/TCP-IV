using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : Elemento
{
    public abstract void OnNotificacao(Notificacao evento_caminho, Object alvo);
}