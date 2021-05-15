using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class Fase : ScriptableObject
{
    [SerializeField] public Toupeira[] toupeiras;
    [SerializeField] public int maxToupeiras;
    [SerializeField] public int bpm;
   // [SerializeField] private string[] tempos;
    [SerializeField] public Armadilha[] armadilhas;
    [SerializeField] public int jogadorVidas;
    [SerializeField] public AudioClip musica;
    [SerializeField] public AudioClip[] efeitos;
}
