using UnityEngine;

public class ToupeiraModel : Elemento
{
    public int Vida { get; set; }
    public int Pontos { get; set; }
    public int PontosPowerUp { get; set; }
    public int Raridade { get; set; }
    public float Velocidade { get; set; }
    public int BpmFase { get; set; }
    public float TemposNaTela { get; set; }
    public int[] DancasId { get; set; }
    public Comportamento Comportamento { get; set; }
    public GameObject Buraco { get; set; }
    public AudioClip SomAoSurgir { get; set; }
    public AudioClip SomPancada { get; set; }
    public Vector3 Posicao
    {
        get
        {
            return gameObject.transform.position;
        }
        set
        {
            gameObject.transform.position = value;
        }
    }
    public GameObject AcertouEfeito { get; set; }
}

public enum Comportamento
{
    Fofo,
    Doido,    
    PoucosAmigos,
    Lider
}
