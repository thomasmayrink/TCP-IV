/*
using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private Estado estado;

    private float timerFase;
    private float temposPrimeiraInstancia;
    private float timerEntreInstancias;
    private float batidasPorSegundo;
    private float[] tempos;

    private void Start()
    {
        this.estado = Estado.Rodando;
        this.timerFase = 0;
        this.timerEntreInstancias = 0;
        app.Notificar(Notificacao.Fase.Inicio, this);
    }

    private void Update()
    {
        switch (estado)
        {
            case Estado.Rodando:
                break;

            case Estado.CriarToupeiras:
                break;

            case Estado.CriarArmadilhas:
                break;
        }
    }

    private enum Estado
    {
        Rodando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
*/

using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private float timerInstancias;
    private float timerFase;
    public float batidasPorSegundo { get; set; }
    public float timerInstanciasMax { get; set; }

    public float[] tempos { get; set; }
    public float timerFaseMax { get; set; }

    private Estado estado { get; set; }

    private void Start()
    {
        app.Notificar(Notificacao.Fase.Inicio, this);

        estado = Estado.Rodando;
    }

    private void Update()
    {
        timerInstancias += Time.deltaTime;
        timerFase += Time.deltaTime;

        switch (estado)
        {
            case Estado.Rodando:
                app.DebugFase("timerInstancias = " + timerInstancias);
                app.DebugFase("timerInstanciasMax / batidasPorSegundo = " + timerInstanciasMax / batidasPorSegundo);
                app.DebugFase("timerInstancias >= timerInstanciasMax / batidasPorSegundo = " + (timerInstancias >= timerInstanciasMax / batidasPorSegundo));
               
                if (timerInstancias >= timerInstanciasMax / batidasPorSegundo)
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
                SortearTempo();
                estado = Estado.Rodando;
                break;

            case Estado.CriarArmadilhas:
                break;
        }
    }

    public float SortearTempo()
    {
        return timerInstanciasMax = tempos[Random.Range(0, tempos.Length)];
    }

    public void CriarToupeiras(int maxToupeiras, List<GameObject> buracosDisponiveis, List<Toupeira> toupeiras, int bpm, AudioClip somAoSurgir, AudioClip somPancada)
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
                                                                           toupeira,
                                                                           bpm,
                                                                           somAoSurgir,
                                                                           somPancada);
            }
        }
        else
        {
            for (int i = 0; i < buracosDisponiveis.Count; i++)
            {
                Toupeira toupeira = toupeiras[Random.Range(0, toupeiras.Count)];
                buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.toupeiraPrefab,
                                                                           toupeira,
                                                                           bpm,
                                                                           somAoSurgir, 
                                                                           somPancada);
            }
        }
    }

    private enum Estado
    {
        Rodando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
