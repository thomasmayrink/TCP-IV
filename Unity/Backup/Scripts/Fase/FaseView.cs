using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private float timerInstancias;
    private float timerFase;
    public float batidasPorSegundo { get; set; }
    public float temposPrimeiraInstancia { get; set; }
    public float timerInstanciasMax { get; set; }

    public float[] tempos { get; set; }
    public float timerFaseMax { get; set; }

    private Estado estado { get; set; }

    private void Start()
    {
        app.Notificar(Notificacao.Fase.Inicio, this);

        estado = Estado.Esperando;
    }

    private void Update()
    {
        timerInstancias += Time.deltaTime;
        timerFase += Time.deltaTime;

        switch (estado)
        {
            case Estado.Esperando:
                if (timerFase >= temposPrimeiraInstancia)
                {
                    timerInstancias = 0;
                    estado = Estado.Rodando;
                }
                break;

            case Estado.Rodando:
                app.DebugFase("View Rodando");
                app.DebugFase("batidas por segundo: " + batidasPorSegundo);
                if (timerInstancias >= timerInstanciasMax * batidasPorSegundo)
                {
                    timerInstancias = 0;
                    app.Notificar(Notificacao.Fase.CriarToupeiras, this);
                    estado = Estado.CriarToupeiras;
                }

                if (timerFaseMax != 0)
                {
                    if (timerFase >= timerFaseMax)
                    {
                        app.Notificar(Notificacao.Fase.Fim, this);
                    }
                }
                break;

            case Estado.CriarToupeiras:
                app.DebugFase("View CriarToupeiras");
                SortearTempo();
                app.DebugFase("View: timerInstanciasMax = " + timerInstanciasMax);
                estado = Estado.Rodando;
                break;

            case Estado.CriarArmadilhas:
                app.DebugFase("View CriarArmadilhas");
                break;
        }
    }

    public float SortearTempo()
    {
        return timerInstanciasMax = tempos[Random.Range(0, tempos.Length)];
    }

    public void CriarToupeiras(int maxToupeiras, List<GameObject> buracosDisponiveis, List<Toupeira> toupeiras)
    {
        int maxInstancias = Random.Range(0, maxToupeiras);
        if (maxInstancias <= 1) maxInstancias = Random.Range(0, maxToupeiras);
        if (maxInstancias <= 1) maxInstancias = Random.Range(0, maxToupeiras);

        //Levar raridades em consideracao (atribuir raridade à não instanciar ninguém(0))

        Utilidades.SortearLista(buracosDisponiveis);

        
        if (maxInstancias <= buracosDisponiveis.Count)
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

    private enum Estado
    {
        Esperando,
        Rodando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
