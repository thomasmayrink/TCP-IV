using UnityEngine;

public abstract class BaseObjetoModel : Elemento
{ 
    public int Vida { get; set; }
    public int Pontos { get; set; }
    public int PontosPowerUp { get; set; }
    public float Velocidade { get; set; }
    public int Dano { get; set; }
    public int Raridade { get; set; }
    public float TemposNaTela { get; set; }
    public GameObject Prefab { get; set; }
    public float BpmFase { get; set; }
    public GameObject Buraco { get; set; }
    public AudioClip SomAoSurgir { get; set; }
    public AudioClip SomPancada { get; set; }
    public AudioClip SomDano { get; set; }
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
