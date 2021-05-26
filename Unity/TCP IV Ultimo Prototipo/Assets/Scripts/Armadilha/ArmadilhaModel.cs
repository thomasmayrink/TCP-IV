using UnityEngine;

public class ArmadilhaModel : Elemento
{
    public int Dano { get; set; }
    public int Raridade { get; set; }
    public float TemposNaTela { get; set; }
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