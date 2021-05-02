using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartidaController : Controller
{
    public override void OnNotificacao(Notificacao notificacao, Object p_target)
    {
        switch (notificacao)
        {
            case Notificacao.BOLA_ACERTOU_CHAO:
                Debug.Log("BOLA_ACERTOU_CHAO");
                break;

            case Notificacao.GAME_OVER:
                Debug.Log("GameOver");
                break;
        }
    }
}
