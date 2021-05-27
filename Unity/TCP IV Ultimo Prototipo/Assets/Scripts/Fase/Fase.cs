using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "WhackAMole/Fase")]
public class Fase : ScriptableObject
{
    [SerializeField] public int jogadorVidas;
    [SerializeField] public List<Toupeira> toupeiras;
    [SerializeField] public int maxToupeiras;
    [SerializeField] public float[] temposCriarToupeiras;
    [SerializeField] public List<Armadilha> armadilhas;
    [SerializeField] public int maxArmadilhas;
    [SerializeField] public AudioClip[] musicas;
    [SerializeField] public int bpm;
    [SerializeField] public AudioClip[] sonsToupeiraSurgindo;
    [SerializeField] public AudioClip[] sonsToupeiraAcertou;
    [SerializeField] public GameObject acertouEfeito;
    [SerializeField] public float minSemAtividade;
}
