using UnityEngine;

public abstract class BaseObjeto : ScriptableObject
{
    [SerializeField] public int vida;
    [SerializeField] public int pontos;
    [SerializeField] [Range(0, 100)] public int pontosPowerUp;
    [SerializeField] public float velocidade;
    [SerializeField] public int dano;
    [SerializeField] [Range(0, 5)] public int raridade;
    [SerializeField] public float temposNaTela;
    [SerializeField] public GameObject prefab;
}
