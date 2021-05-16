using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private float timerInstancias;
    private float timerFase;
    public float timerInstanciasMax { get; set; }
    public float timerFaseMax { get; set; }

    private Estado estado { get; set; }

    private void Start()
    {
        estado = Estado.Esperando;
        app.Notificar(Notificacao.Fase.Inicio, this);
    }

    private void Update()
    {
        timerInstancias += Time.deltaTime;
        timerFase += Time.deltaTime;

        switch (estado)
        {
            case Estado.Esperando:
                app.DebugFase("View Esperando");

                if (timerInstancias >= timerInstanciasMax)
                {
                    timerInstancias = 0;
                    app.Notificar(Notificacao.Fase.CriarToupeiras, this);
                    estado = Estado.CriarToupeiras;
                }

                if (timerFase >= timerFaseMax)
                {
                    app.Notificar(Notificacao.Fase.Fim, this);
                }
                
                break;

            case Estado.CriarToupeiras:
                app.DebugFase("View CriarToupeiras");
                estado = Estado.Esperando;
                break;

            case Estado.CriarArmadilhas:
                app.DebugFase("View CriarArmadilhas");
                break;
        }
    }

    public void CriarToupeiras(int maxToupeiras, List<GameObject> buracosDisponiveis, List<Toupeira> toupeiras)
    {
        int maxInstancias = Random.Range(0, maxToupeiras + 1);
        if (maxInstancias >= (maxToupeiras + 1) / 2) maxInstancias = Random.Range(0, maxToupeiras + 1);

        //Levar raridades em consideracao (atribuir raridade à não instanciar ninguém(0))

        Utilidades.SortearLista(buracosDisponiveis);

        
        if (maxInstancias < buracosDisponiveis.Count)
        {
            for (int i = 0; i < maxInstancias; i++)
            {
                Toupeira toupeira = toupeiras[Random.Range(0, toupeiras.Count)];
                buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.toupeiraPrefab,
                                                                           toupeira);
            }
        }
        else
        {
            for (int i = 0; i < buracosDisponiveis.Count; i++)
            {
                Toupeira toupeira = toupeiras[Random.Range(0, toupeiras.Count)];
                buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.toupeiraPrefab,
                                                                           toupeira);
            }
        }
    }

    public enum Estado
    {
        Esperando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
