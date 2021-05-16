using UnityEngine;

public class Buraco : MonoBehaviour
{
    public bool EstaOcupado { get; set; }
    private bool desocupar = false;
    private float timer;

    public void CriarToupeira(GameObject toupeira, Toupeira toupeiraAtr)
    {
        Vector3 pos = this.gameObject.transform.position + new Vector3(0, -2.8f, 0);
        toupeira = Instantiate(toupeira, pos, Quaternion.identity);
        FabricaToupeira.Criar(toupeira.GetComponent<ToupeiraModel>(), toupeiraAtr, gameObject);

        EstaOcupado = true;
    }

    public void Desocupar()
    {
        desocupar = true;
    }

    private void Update()
    {
        if (desocupar)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                EstaOcupado = false;
                desocupar = false;
                timer = 0;
            }
        }

    }
}
