using UnityEngine;

[CreateAssetMenu]
public class Toupeira : ScriptableObject
{
    [SerializeField] public int vida;
    [SerializeField] public int pontos;
    //[SerializeField] public float velocidade;
    [SerializeField] [Range(0, 1)] public float tempoNaTela;
    [SerializeField] public int[] dancasId;
    [SerializeField] public GameObject toupeiraPrefab;
    [SerializeField] public Comportamento comportamento;
}
