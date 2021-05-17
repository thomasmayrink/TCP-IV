using UnityEngine;

public class ToupeiraModel : Elemento
{
    public int Vida { get; set; }
    public int Pontos { get; set; }
    public int Raridade { get; set; }
    public float Velocidade { get; set; }
    public int TemposNaTela { get; set; }
    public int[] DancasId { get; set; }
    public Comportamento Comportamento { get; set; }
    public GameObject Buraco { get; set; }
    public bool PodeSerAcertada { get; set; }
    //public bool EstaDescendo { get; set; }
    public AudioClip[] SomAoSurgir { get; set; }
    public AudioClip[] SomPancada { get; set; }
}

public enum Comportamento
{
    Lider,
    Doido,
    PoucosAmigos,
    Fofo
}
