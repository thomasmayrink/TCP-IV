using UnityEngine;

[CreateAssetMenu(menuName = "WhackAMole/Armadilha")]
public class Armadilha : AbstratoObjeto
{
    //[SerializeField] public int danoAoClicar;
    //   [SerializeField] [Range(0, 5)] public int raridade;
    //   [SerializeField] public float temposNaTela;
    [SerializeField] public ArmadilhaTipo tipoDeAmadilha;
    [SerializeField] public AudioClip somAoSurgir;
    [SerializeField] public AudioClip somPancada;
    //[SerializeField] public GameObject acertouEfeito;
}
