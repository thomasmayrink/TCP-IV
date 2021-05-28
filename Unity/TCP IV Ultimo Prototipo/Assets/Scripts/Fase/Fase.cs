using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "WhackAMole/Fase")]
public class Fase : ScriptableObject
{
    [SerializeField] public int jogadorVidas;
    [SerializeField] public List<Toupeira> toupeiras;
    [SerializeField] public int maxToupeiras;
    [SerializeField] public List<Armadilha> armadilhas;
    [SerializeField] public int maxArmadilhas;
    [SerializeField] public int proporcao;
    [SerializeField] public float[] temposCriar;
    [SerializeField] public AudioClip[] musicas;
    [SerializeField] public int bpmInicial;
    [SerializeField] public int bpmMax;
    [SerializeField] public AudioClip[] sonsSurgindo;
    [SerializeField] public AudioClip[] sonsAcertou;
    [SerializeField] public AudioClip[] sonsDano;
    [SerializeField] public AudioClip[] sonsFugiu;
    [SerializeField] public float minSemAtividade;
    [SerializeField] public GameObject acertouEfeito;
}
