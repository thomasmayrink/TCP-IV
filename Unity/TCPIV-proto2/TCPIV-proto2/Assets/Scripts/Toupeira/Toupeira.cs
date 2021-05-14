using UnityEngine;

[CreateAssetMenu]
public class Toupeira : ScriptableObject
{
    [SerializeField] public float velocidade;
    [SerializeField] public int vida;
    [SerializeField] public int[] dancasId;
    [SerializeField] public GameObject toupeiraPrefab;
    [SerializeField] public Comportamento comportamento;
}
