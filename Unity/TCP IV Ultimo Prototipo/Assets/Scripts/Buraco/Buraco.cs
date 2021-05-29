using UnityEngine;

public class Buraco : MonoBehaviour
{
    private bool estaOcupado;
    private GameObject toupeira;
    private GameObject armadilha;

    public bool EstaOcupado
    {
        get
        {
            return estaOcupado;
        }
        set
        {
            estaOcupado = value;
        }
    }
    public GameObject Toupeira
    {
        get
        {
            return toupeira;
        }
    }
    public GameObject Armadilha
    {
        get
        {
            return armadilha;
        }
    }

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
        estaOcupado = true;
        this.toupeira = toupeira;
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
        estaOcupado = true;
        this.armadilha = armadilha;
    }

    public void MatarToupeira(GameObject acertouEfeito)
    {
        try
        {
            toupeira.GetComponent<ToupeiraView>().Matou(acertouEfeito);
        }
        catch
        {
            AcertarArmadilha(acertouEfeito);
        }
    }

    public void AcertarArmadilha(GameObject acertouEfeito)
    {
        armadilha.GetComponent<ArmadilhaView>().Acertou(acertouEfeito);
    }
}
