using UnityEngine;

public class Buraco : MonoBehaviour
{
    public bool EstaOcupado { get; set; }
    public GameObject CriarToupeira(GameObject toupeira)
    {
        EstaOcupado = true;
        return Instantiate(toupeira,
                           this.gameObject.transform.position + new Vector3(0, -2.5f, 0),
                           Quaternion.identity);
    }
}
