using UnityEngine;

[CreateAssetMenu(menuName = "WhackAMole/Armadilha")]
public class Armadilha : BaseObjeto
{
    [SerializeField] public ArmadilhaTipo tipoDeAmadilha;
    [SerializeField] public AudioClip somAoSurgir;
    [SerializeField] public AudioClip somPancada;
}
