using UnityEngine;

[CreateAssetMenu]
public class Toupeira : ScriptableObject
{
    #region VARIAVEIS
    
    [SerializeField] private float velocidade;
    [SerializeField] private int vida;
    [SerializeField] private int[] dancasId;
    [SerializeField] private GameObject toupeiraPrefab;
    [SerializeField] private COMPORTAMENTO comportamento;
    
    #endregion

    #region PROPRIEDADES
   
    public float Velocidade
    {
        get
        {
            return velocidade;
        }
        set
        {
            velocidade = value;
        }
    }

    public int Vida
    {
        get
        {
            return vida;
        }
        set
        {
            vida = value;
        }
    }

    public int[] DancasId
    {
        get
        {
            return dancasId;
        }
        set
        {
            dancasId = value;
        }
    }
    
    public GameObject ToupeiraPrefab
    {
        get
        {
            if (toupeiraPrefab == null)
            {
                Debug.Log("<color=red>ERRO! </color>Nenhum prefab foi colocado no campo Toupeira Prefab em Toupeira.");
            }
            return toupeiraPrefab;
        }
    }

    public COMPORTAMENTO Comportamento
    {
        get
        {
            return comportamento;
        }
    }

    public ToupeiraController Controller {
        get
        {
            return toupeiraPrefab.GetComponent<ToupeiraController>();
        }
    }

    public Vector3 Posicao { get; set; }

    public bool FoiAcertada { get; set; }

    public bool PodeSerAcertada { get; set; }

    public bool DeveSerDestruida { get; set; }

    #endregion
}

public enum COMPORTAMENTO
{
    Lider,
    Doido,
    PoucosAmigos,
    Fofo
}
