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

    private static List<Toupeira> toupeirasRaridade;

    private Estado estado;

    private void Start()
    {
        toupeirasRaridade = new List<Toupeira>();

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
        SortearToupeiras(toupeiras);

        int maxInstancias = Random.Range(1, maxToupeiras + 1);

        Utilidades.SortearLista(buracosDisponiveis);
        try
        {
            Toupeira toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];
            if (toupeira.comportamento == Comportamento.Lider)
            {
                buracosDisponiveis[Random.Range(0, buracosDisponiveis.Count)].GetComponent<Buraco>().CriarToupeira(toupeira.toupeiraPrefab,
                                                                                                                   toupeira,
                                                                                                                   bpm,
                                                                                                                   somAoSurgir,
                                                                                                                   somPancada,
                                                                                                                   acertouEfeito);
            }
            else
            {
                if (maxInstancias <= buracosDisponiveis.Count)
                {
                    for (int i = 0; i < maxInstancias; i++)
                    {
                        toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];
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
                        toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];
                        buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.toupeiraPrefab,
                                                                                   toupeira,
                                                                                   bpm,
                                                                                   somAoSurgir,
                                                                                   somPancada,
                                                                                   acertouEfeito);
                    }
                }
            }
        }
        catch 
        {
            app.DebugFase("ERRO");
        }
    }

    private void SortearToupeiras(List<Toupeira> toupeiras)
    {
        toupeirasRaridade.Clear();

        #region REFAZER_MELHOR
        //REFAZER MELHOR
        int sorte = Random.Range(0, 24);

        switch (sorte)
        {
            case 0:
                app.DebugFase("5%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 1)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 0 && n <= 3:
                app.DebugFase("15%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 2)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 3 && n <= 7:
                app.DebugFase("20%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 3)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 8 && n <= 12:
                app.DebugFase("25%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 4)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 12 && n <= 24:
                app.DebugFase("60%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 5)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;
        }
        #endregion
        //adiciono as toupeiras da raridade correspondente (talvez dê pra usar pra armadilha também)
        //retorno a lista e uso o count dela pro max do Random
    }

    private enum Estado
    {
        Rodando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
