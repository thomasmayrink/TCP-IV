using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Separar Model do ScriptableObject
public enum Notificacao
{
    JogoIniciado,
    JogadorAcertou,
    JogadorErrou,
    JogadorUsouPowerUp,
    ToupeiraFoiAcertada,
    ToupeiraMorreu,
    ToupeiraFugiu,
    JogoAcabou
}