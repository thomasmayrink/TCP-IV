using UnityEngine;

public class ArmadilhaModel : BaseObjetoModel
{
    public ArmadilhaTipo TipoDeArmadilha { get; set; }
}

public enum ArmadilhaTipo
{
    Espinho,
    Bomba,
    Urso
}