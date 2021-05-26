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
    public float[] TemposCriarToupeiras
    {
        get
        {
            return fase.temposCriarToupeiras;
        }
    }
    public List<Armadilha> Armadilhas
    {
        get
        {
            return fase.armadilhas;
        }
    }
    public int MaxArmadilhas
    {
        get
        {
            return fase.maxArmadilhas;
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
    public int Bpm
    {
        get
        {
            return fase.bpm;
        }
    }
    public float BatidasPorSegundo
    { 
        get
        {
            return fase.bpm / 60f;
        }
    }

    public AudioClip SomToupeiraSurgindo
    {
        get
        {
            return fase.somToupeiraSurgindo;
        }
    }
    public AudioClip SomToupeiraAcertou
    {
        get
        {
            return fase.somToupeiraAcertou;
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
    public GameObject AcertouEfeito
    {
        get
        {
            return fase.acertouEfeito;
        }
    }
}
