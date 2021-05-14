using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private float timer;
    public float timerMax { get; set; }

    public Estado estado { get; set; }

    private void Start()
    {
        estado = Estado.Esperando;
        app.Notificar(Notificacao.Fase.Inicio, this);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("Timer:" + timer);

        switch (estado)
        {
            case Estado.Esperando:
                app.DebugView("fase Esperando");

                if (timer >= timerMax)
                {
                    app.DebugView("fase timerMax: " + timerMax);
                    timer = 0;
                    app.Notificar(Notificacao.Fase.CriarToupeiras, this);
                    estado = Estado.CriarToupeiras;
                }

                break;

            case Estado.Rodando:
                app.DebugView("fase Rodando");
                break;

            case Estado.CriarToupeiras:
                app.DebugView("fase CriarToupeiras");
                estado = Estado.Esperando;
                break;

            case Estado.CriarArmadilhas:
                app.DebugView("fase CriarArmadilhas");
                break;
        }
    }

    public void CriarToupeiras(List<GameObject> buracosDisponiveis, Toupeira[] toupeiras)
    {
        int maxInstancias = Random.Range(0, buracosDisponiveis.Count + 1);

        Utilidades.SortearLista(buracosDisponiveis);
        
        for (int i = 0; i < maxInstancias; i++)
        {
            Toupeira toupeira = toupeiras[Random.Range(0, toupeiras.Length)];
            buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.toupeiraPrefab,
                                                                       toupeira);
        }
    }

    public enum Estado
    {
        Esperando,
        Rodando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
