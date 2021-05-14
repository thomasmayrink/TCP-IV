using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class Fase : ScriptableObject
{
    [SerializeField] public Toupeira[] toupeiras;
    [SerializeField] public int bpm;
    [SerializeField] public Armadilha[] armadilhas;
    [SerializeField] public int jogadorVidas;
}
