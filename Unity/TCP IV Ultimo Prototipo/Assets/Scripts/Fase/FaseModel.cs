using System.Collections.Generic;
using UnityEngine;

public class FaseModel : Elemento
{
    [SerializeField] private Fase fase;
    private List<GameObject> buracosDisponiveis;

    public List<Toupeira> Toupeiras
    {
        get
        {
            return fase.toupeiras;
        }
    }
    public int MaxToupeiras
    {
        get
        {
            return fase.maxToupeiras;
        }
    }
    public int Bpm
    {
        get
        {
            return fase.bpm;
        }
    }
    public AudioClip Musica
    {
        get
        {
            return fase.musica;
        }
    }
    public float TamanhoDaMusica
    {
        get
        {
            return fase.musica.length;
        }
    }
    public CondicaoDeFimDeFase CondicaoDeFimDeFase
    {
        get
        {
            return fase.condicaoDeFimDeFase;
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
    public GameObject[] Buracos
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Buraco");
        }
    }
    public List<GameObject> BuracosDisponiveis
    {
        get
        {
            if (buracosDisponiveis == null)
            {
                buracosDisponiveis = new List<GameObject>();
            }
            else
            {
                buracosDisponiveis.Clear();
            }

            foreach(GameObject go in Buracos)
            {
                if (!go.GetComponent<Buraco>().EstaOcupado)
                {
                    buracosDisponiveis.Add(go);
                }
            }
            return buracosDisponiveis;
        }
    }

    public int JogadorVidas { get; set; }
    public int JogadorPontos { get; set; }
    public float BatidasPorSegundo { get; set; }
}
