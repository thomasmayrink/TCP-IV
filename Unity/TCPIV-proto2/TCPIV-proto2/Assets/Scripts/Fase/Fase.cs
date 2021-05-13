using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class Fase : ScriptableObject
{
    #region VARIAVEIS

    [SerializeField] private Toupeira[] toupeiras;
    [SerializeField] private int bpm;
    [SerializeField] private Armadilha[] armadilhas;
    [SerializeField] private int vidas;

    #endregion

    #region PROPRIEDADES

    public Toupeira[] Toupeiras
    {
        get
        {
            return toupeiras;
        }
    }

    public LinkedList<GameObject> ToupeirasInstancias { get; set; }

    public int Bpm
    {
        get
        {
            return bpm;
        }
    }

    public Armadilha[] Armadilhas
    {
        get
        {
            return armadilhas;
        }
    }

    public GameObject[] Buracos
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Buraco");
        }
    }

    public List<KeyValuePair<int, GameObject>> ToupeiraBuraco { get; set; }

    public int QtdBuracosOcupados { get; set; }

    public int Pontos { get; set; }

    public int Vidas { get; set; }
    
    #endregion
}
