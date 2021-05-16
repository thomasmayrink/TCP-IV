using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class Fase : ScriptableObject
{
    [SerializeField] public List<Toupeira> toupeiras;
    [SerializeField] public int maxToupeiras;
    [SerializeField] public int bpm;
    [SerializeField] public Armadilha[] armadilhas;
    [SerializeField] public int jogadorVidas;
    [SerializeField] public AudioClip musica;
    [SerializeField] public AudioClip[] efeitos;
    [SerializeField] public CondicaoDeFimDeFase condicaoDeFimDeFase;
}
public enum CondicaoDeFimDeFase
{
    JogadorSemVidas,
    FimDaMusica
}
