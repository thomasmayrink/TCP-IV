using System.Collections.Generic;
using UnityEngine;

public class FaseModel : Elemento
{
    [SerializeField] private Fase fase;

    public Toupeira[] Toupeiras
    {
        get
        {
            return fase.toupeiras;
        }
    }
    public int Bpm
    {
        get
        {
            return fase.bpm;
        }
    }
    public Armadilha[] Armadilhas 
    { 
        get
        {
            return fase.armadilhas;
        }
    }
    public int JogadorVidasIniciais
    {
        get
        {
            return fase.jogadorVidas;
        }
    }
    public int JogadorVidas { get; set; }
    public int QtdBuracosOcupados { get; set; }
    public int Pontos { get; set; }
    public float IntervaloEntreInstancias { get; set; }
    public GameObject[] Buracos
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Buraco");
        }
    }
}
