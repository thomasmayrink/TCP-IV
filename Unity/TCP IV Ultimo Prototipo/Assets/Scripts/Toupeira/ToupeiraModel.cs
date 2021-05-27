using UnityEngine;

public class ToupeiraModel : BaseObjetoModel
{
    public float BpmFase { get; set; }
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
