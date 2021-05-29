using System.Collections.Generic;
using UnityEngine;

public class FaseModel : Elemento
{
    [SerializeField] private Fase fase;
    private float bpm;
    private List<float> tamanhoDasMusicas;
    private List<GameObject> buracosOcupados;
    private List<GameObject> buracosDisponiveis;

    public int JogadorVidas
    {
        get
        {
            return 3;// fase.jogadorVidas;
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
    public float[] TemposCriar
    {
        get
        {
            return fase.temposCriar;
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
    public int Proporcao
    {
        get
        {
            return fase.proporcao;
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
    public float Bpm
    {
        get
        {
            if (bpm <= 0)
            {
                return fase.bpmInicial;
            }
            else return bpm;
        }
        set
        {
            bpm = value;
        }
    }
    public float BpmMax
    {
        get
        {
            return fase.bpmMax;
        }
    }
    public float BatidasPorSegundo
    { 
        get
        {
            return fase.bpmInicial / 60f;
        }
    }

    public AudioClip[] SonsSurgindo
    {
        get
        {
            return fase.sonsSurgindo;
        }
    }
    public AudioClip[] SonsAcertou
    {
        get
        {
            return fase.sonsAcertou;
        }
    }
    public AudioClip[] SonsDano
    {
        get
        {
            return fase.sonsDano;
        }
    }
    /*
    public AudioClip[] SonsFugiu
    {
        get
        {
            return fase.sonsFugiu;
        }
    }
    */
    public GameObject[] Buracos
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Buraco");
        }
    }
    public List<GameObject> BuracosOcupados
    {
        get
        {
            if (buracosOcupados == null)
            {
                buracosOcupados = new List<GameObject>();
            }
            else
            {
                buracosOcupados.Clear();
            }

            foreach (GameObject go in Buracos)
            {
                if (go.GetComponent<Buraco>().EstaOcupado)
                {
                    buracosOcupados.Add(go);
                }
            }
            return buracosOcupados;
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
