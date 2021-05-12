using UnityEngine;

[CreateAssetMenu]
public class Fase : ScriptableObject
{
    #region VARIAVEIS

    [SerializeField] private Toupeira[] toupeiras;
    [SerializeField] private int intervaloMinCriarToupeira;
    [SerializeField] private int intervaloMaxCriarToupeira;
    //[SerializeField] private ARMADILHA[] armadilhas;
    private bool[] buracosOcupados;

    #endregion

    #region PROPRIEDADES

    public Toupeira[] Toupeiras
    {
        get
        {
            if (toupeiras != null)
            {
                foreach (Toupeira t in toupeiras)
                {
                    t.Controller.model = t;
                }
            } 
            else
            {
                Debug.Log("<color=red>ERRO! </color>Nenhuma Toupeira foi colocada no campo Toupeiras em Fase.");
            }
            return toupeiras;
        }
    }

    public int IntervaloMinCriarToupeira
    {
        get
        {
            return intervaloMinCriarToupeira;
        }
    }

    public int IntervaloMaxCriarToupeira
    {
        get
        {
            return intervaloMaxCriarToupeira;
        }
    }

    public GameObject[] Buracos
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Buraco");
        }
    }

    public bool[] BuracosOcupados
    {
        get
        {
            if (BuracosOcupados == null)
            {
                return buracosOcupados = new bool[Buracos.Length];
            }
            else return buracosOcupados;
        }
        set
        {
            buracosOcupados = value;
        }
    }

    #endregion
}
