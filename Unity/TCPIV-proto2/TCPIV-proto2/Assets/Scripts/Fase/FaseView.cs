using UnityEngine;

public class FaseView : Elemento
{
    public float timer { get; set; }
    private Estado estado;

    private void Start()
    {
        estado = Estado.Esperando;
        app.Notificar(Notificacao.Fase.Inicio, this);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        switch (estado)
        {
            case Estado.Esperando:
                break;

            case Estado.CriarToupeiras:
                app.Notificar(Notificacao.Fase.CriarToupeiras, this);
                break;

            case Estado.CriarArmadilhas:
                
                break;
        }
    }
    
    public void CriarToupeira(Toupeira[] toupeiras, int buracosTotal, int qtdBuracosOcupados, ToupeiraModel toupeiraModel, Vector3 posicao)
    {
        int random = Random.Range(0, buracosTotal - qtdBuracosOcupados);
        for (int i = 0; i < random; i++)
        {
            CriarToupeira toupeira = new CriarToupeira(toupeiras[Random.Range(0, toupeiras.Length)], toupeiraModel, posicao);
        }
        estado = Estado.Esperando;
    }

    private enum Estado
    {
        Esperando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
