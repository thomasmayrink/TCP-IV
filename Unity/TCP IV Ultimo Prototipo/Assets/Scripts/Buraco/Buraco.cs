using UnityEngine;

public class Buraco : MonoBehaviour
{
    public bool EstaOcupado { get; set; }

    public void CriarToupeira(GameObject toupeira, 
                              Toupeira toupeiraAtr,
                              float bpm, 
                              AudioClip somAoSurgir,
                              AudioClip somPancada,
                              AudioClip somDano,
                              //AudioClip somFugiu,
                              GameObject acertouEfeito)
    {
        Vector3 pos = gameObject.transform.position + new Vector3(0, -2.8f, 0);
        toupeira = Instantiate(toupeira, pos, Quaternion.identity);
        Fabrica.Toupeira(toupeira.GetComponent<ToupeiraModel>(), toupeiraAtr, bpm, gameObject, somAoSurgir, somPancada, somDano, acertouEfeito); //, somFugiu
        EstaOcupado = true;
    }

    public void CriarArmadilha(GameObject armadilha, 
                               Armadilha armadilhaAtr, 
                               float bpm, 
                               AudioClip somAoSurgir,
                               AudioClip somPancada,
                               AudioClip somDano, 
                               GameObject acertouEfeito)
    {
        Vector3 pos = gameObject.transform.position + new Vector3(0, -2.8f, 0);
        armadilha = Instantiate(armadilha, pos, Quaternion.identity);
        Fabrica.Armadilha(armadilha.GetComponent<ArmadilhaModel>(), armadilhaAtr, bpm, gameObject, somAoSurgir, somPancada, somDano, acertouEfeito);
        EstaOcupado = true;
    }
}
