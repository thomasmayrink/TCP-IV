using UnityEngine;

[CreateAssetMenu(menuName = "WhackAMole/Toupeira")]
public class Toupeira : AbstratoObjeto
{
   // [SerializeField] public int vida;
    //[SerializeField] public int pontos;
    //[SerializeField] [Range(0,100)] public int pontosPowerUp;
 //   [SerializeField] [Range (0,5)] public int raridade;
  //  [SerializeField] public float velocidade;
   // [SerializeField] public float temposNaTela;
    [SerializeField] public int[] dancasId;
    [SerializeField] public Comportamento comportamento;
    //[SerializeField] public GameObject toupeiraPrefab;
}
