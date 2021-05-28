using UnityEngine;

public class ToupeiraModel : BaseObjetoModel
{
    public int[] DancasId { get; set; }
    public Comportamento Comportamento { get; set; }
    //public AudioClip SomFugiu { get; set; }
}

public enum Comportamento
{
    Fofo,
    Doido,    
    PoucosAmigos,
    Lider
}
