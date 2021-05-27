using System.Collections.Generic;
using UnityEngine;

public class FaseModel : Elemento
{
    [SerializeField] private Fase fase;
    private List<float> tamanhoDasMusicas;
    private List<GameObject> buracosDisponiveis;

    public int JogadorVidas
    {
        get
        {
            return fase.jogadorVidas;
        }
    }
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
    public AudioClip[] Musicas
    {
        get
        {
            return fase.musicas;
        }
    }
    public List<float> TamanhoDasMusicas
    {
        get
        {
            if (tamanhoDasMusicas == null)
            {
                tamanhoDasMusicas = new List<float>();
            }
            foreach (AudioClip a in Musicas)
            {
                tamanhoDasMusicas.Add(a.length);
            }
            return tamanhoDasMusicas;
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

    public AudioClip[] SonsToupeiraSurgindo
    {
        get
        {
            return fase.sonsToupeiraSurgindo;
        }
    }
    public AudioClip[] SonsToupeiraAcertou
    {
        get
        {
            return fase.sonsToupeiraAcertou;
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
    public float MinSemAtividade
    {
        get
        {
            return fase.minSemAtividade;
        }
    }
}
