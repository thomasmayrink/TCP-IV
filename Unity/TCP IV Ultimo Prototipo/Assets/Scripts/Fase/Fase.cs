using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "WhackAMole/Fase")]
public class Fase : ScriptableObject
{
    [SerializeField] public List<Toupeira> toupeiras;
    [SerializeField] public int maxToupeiras;
    [SerializeField] public float[] temposCriarToupeiras;
    [SerializeField] public AudioClip musica;
    [SerializeField] public int bpm;
    [SerializeField] public Armadilha[] armadilhas;
    [SerializeField] public int jogadorVidas;
    [SerializeField] public AudioClip[] efeitos;
    [SerializeField] public CondicaoDeFimDeFase fimDeFase;
}
public enum CondicaoDeFimDeFase
{
    JogadorSemVidas,
    FimDaMusica,
}
