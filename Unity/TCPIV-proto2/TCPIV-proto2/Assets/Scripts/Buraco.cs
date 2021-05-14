using UnityEngine;

public class Buraco : Controller
{
    public bool EstaOcupado { get; set; }
    public GameObject CriarToupeira(GameObject toupeira)
    {
        EstaOcupado = true;
        return Instantiate(toupeira,
                           this.gameObject.transform.position + new Vector3(0, -2.5f, 0),
                           Quaternion.identity);
    }

    public override void OnNotificacao(string evento_caminho, Object alvo, params object[] dados)
    {
        switch (evento_caminho)
        {
            case Notificacao.Fase.CriarToupeiras:
                break;
        }
    }
}
