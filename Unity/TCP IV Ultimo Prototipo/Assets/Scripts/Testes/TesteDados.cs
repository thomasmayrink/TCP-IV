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
  //  public static bool Rodando { get; set; }
    public static float TempoParado
    {
        get
        {
            return 2f;
        }
    }
}
