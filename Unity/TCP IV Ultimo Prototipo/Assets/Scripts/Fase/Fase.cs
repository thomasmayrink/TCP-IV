using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "WhackAMole/Fase")]
public class Fase : ScriptableObject
{
    [SerializeField] public int jogadorVidas;
    [SerializeField] public List<Toupeira> toupeiras;
    [SerializeField] public int maxToupeiras;
    [SerializeField] public float[] temposCriarToupeiras;
    [SerializeField] public Armadilha[] armadilhas;
    [SerializeField] public int maxArmadilhas;
    [SerializeField] public AudioClip musica;
    [SerializeField] public int bpm;
    [SerializeField] public AudioClip somToupeiraSurgindo;
    [SerializeField] public AudioClip somToupeiraAcertou;
    [SerializeField] public GameObject acertouEfeito;
}
