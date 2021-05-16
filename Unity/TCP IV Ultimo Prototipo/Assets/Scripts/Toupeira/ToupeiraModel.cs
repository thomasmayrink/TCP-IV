using UnityEngine;

public class ToupeiraModel : Elemento
{
    public float Velocidade { get; set; }
    public int Vida { get; set; }
    public int[] DancasId { get; set; }
    public Comportamento Comportamento { get; set; }
    public GameObject Buraco { get; set; }
    public bool PodeSerAcertada { get; set; }
    //public bool FoiAcertada { get; set; }
}

public enum Comportamento
{
    Lider,
    Doido,
    PoucosAmigos,
    Fofo
}
