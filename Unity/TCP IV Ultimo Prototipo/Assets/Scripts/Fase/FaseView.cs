using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private float timerInstancias;
    private float timerFase;
    private float batidasPorSegundo;
    private float timerInstanciasMax;

    private float[] tempos;
    private float timerFaseMax;

    private Estado estado;

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

    public void SetFase(float batidasPorSegundo, float[] tempos, float tamanhoDaMusica)
    {
        this.batidasPorSegundo = batidasPorSegundo;
        timerInstanciasMax = 0;
        this.tempos = tempos;
        timerFaseMax = tamanhoDaMusica;
    }

    public float SortearTempo()
    {
        return timerInstanciasMax = tempos[Random.Range(0, tempos.Length)];
    }

    public void CriarToupeiras(int maxToupeiras, List<GameObject> buracosDisponiveis, List<Toupeira> toupeiras, int bpm, AudioClip somAoSurgir, AudioClip somPancada, GameObject acertouEfeito)
    {
        int maxInstancias = Random.Range(0, maxToupeiras + 1);
        if (maxInstancias < 1) maxInstancias = Random.Range(0, maxToupeiras);
        if (maxInstancias < 1) maxInstancias = Random.Range(0, maxToupeiras);

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
                                                                           somPancada,
                                                                           acertouEfeito);
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
                                                                           somPancada,
                                                                           acertouEfeito);
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
