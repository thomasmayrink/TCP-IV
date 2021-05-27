using UnityEngine;

public class ArmadilhaModel : BaseObjetoModel
{
    public ArmadilhaTipo TipoDeArmadilha { get; set; }
    public AudioClip SomAoSurgir { get; set; }
    public AudioClip SomPancada { get; set; }
    public GameObject AcertouEfeito { get; set; }
}

public enum ArmadilhaTipo
{
    Espinho,
    Bomba,
    Urso
}