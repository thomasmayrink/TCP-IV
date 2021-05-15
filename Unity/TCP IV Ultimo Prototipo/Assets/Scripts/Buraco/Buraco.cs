using UnityEngine;

public class Buraco : MonoBehaviour
{
    public bool EstaOcupado { get; set; }
    public void CriarToupeira(GameObject toupeira, Toupeira toupeiraAtr)
    {
        Vector3 pos = this.gameObject.transform.position + new Vector3(0, -2.8f, 0);
        toupeira = Instantiate(toupeira, pos, Quaternion.identity);
        FabricaToupeira.Criar(toupeira.GetComponent<ToupeiraModel>(), toupeiraAtr, pos);

        EstaOcupado = true;
    }
}
