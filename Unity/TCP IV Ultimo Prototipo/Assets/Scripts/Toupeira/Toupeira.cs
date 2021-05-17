using UnityEngine;

[CreateAssetMenu(menuName = "WhackAMole/Toupeira")]
public class Toupeira : ScriptableObject
{
    [SerializeField] public int vida;
    [SerializeField] public int pontos;
    [SerializeField] [Range (0,5)] public int raridade;
    [SerializeField] public float velocidade;
    [SerializeField] public int temposNaTela;
    [SerializeField] public int[] dancasId;
    [SerializeField] public Comportamento comportamento;
    [SerializeField] public GameObject toupeiraPrefab;
    [SerializeField] public AudioClip somAoSurgir;
    [SerializeField] public AudioClip somPancada;
}
