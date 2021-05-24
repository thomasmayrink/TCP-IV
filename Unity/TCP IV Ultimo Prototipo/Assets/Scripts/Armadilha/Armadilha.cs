using UnityEngine;

[CreateAssetMenu(menuName = "WhackAMole/Armadilha")]
public class Armadilha : ScriptableObject
{
    [SerializeField] public int danoAoClicar;
    [SerializeField] [Range(0, 5)] public int raridade;
    [SerializeField] public float temposNaTela;
    [SerializeField] public ArmadilhaTipo tipoDeAmadilha;
}
