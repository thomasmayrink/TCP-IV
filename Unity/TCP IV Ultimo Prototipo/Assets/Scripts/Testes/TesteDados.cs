using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TesteDados
{
    public static int UltimaFaseId { get; set; }
    public static int PontosUltimaFase { get; set; }
    public static GameObject[] Toupeiras
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Toupeira");
        }
    }
    public static bool JogoPausado { get; set; }
    public static bool PowerUp3 { get; set; }
}
