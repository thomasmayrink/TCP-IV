using UnityEngine;

public class Buraco : MonoBehaviour
{
    public bool EstaOcupado { get; set; }

    public void CriarToupeira(GameObject toupeira, Toupeira toupeiraAtr, float bpm, AudioClip somAoSurgir, AudioClip somPancada, GameObject acertouEfeito)
    {
        Vector3 pos = this.gameObject.transform.position + new Vector3(0, -2.8f, 0);
        toupeira = Instantiate(toupeira, pos, Quaternion.identity);
        FabricaToupeira.Criar(toupeira.GetComponent<ToupeiraModel>(), toupeiraAtr, bpm, gameObject, somAoSurgir, somPancada, acertouEfeito);

        EstaOcupado = true;
    }

    public void CriarArmadilha(GameObject armadilha, Armadilha armadilhaAtr, int bpm, AudioClip somAoSurgir, AudioClip somPancada, GameObject acertouEfeito)
    {
        Vector3 pos = this.gameObject.transform.position + new Vector3(0, -2.8f, 0);
        armadilha = Instantiate(armadilha, pos, Quaternion.identity);
        FabricaArmadilha.Criar(armadilha.GetComponent<ArmadilhaModel>(), armadilhaAtr, bpm, acertouEfeito);
    }
}