using UnityEngine;

public class ArmadilhaModel : Elemento
{
    public int DanoAoClicar { get; set; }
    public int Raridade { get; set; }
    public float TemposNaTela { get; set; }
    public ArmadilhaTipo TipoDeArmadilha { get; set; }
}

public enum ArmadilhaTipo
{
    Espinho,
    Bomba,
    Urso
}