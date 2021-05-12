using UnityEngine;

[CreateAssetMenu]
public class Toupeira : ScriptableObject
{
    #region VARIAVEIS
    
    [SerializeField] private float velocidade;
    [SerializeField] private int vida;
    [SerializeField] private int[] dancasId;
    [SerializeField] private GameObject toupeiraPrefab;
    
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
            return toupeiraPrefab;
        }
    }

    public Vector3 Posicao { get; set; }

    public bool FoiAcertada { get; set; }

    public bool PodeSerAcertada { get; set; }

    #endregion
}
