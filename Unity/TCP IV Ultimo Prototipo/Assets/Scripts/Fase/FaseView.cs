using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private static List<Toupeira> toupeirasRaridade;

    private float timerInstancias;
    private float timerInstanciasMax;

    private float batidasPorSegundo;
    private float[] tempos;

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

        switch (estado)
        {
            case Estado.Rodando:               
                if (timerInstancias >= timerInstanciasMax / batidasPorSegundo)
                {
                    timerInstancias = 0;
                    app.Notificar(Notificacao.Fase.CriarToupeiras, this);
                    estado = Estado.CriarToupeiras;
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
    private float SortearTempo()
    {
        return timerInstanciasMax = tempos[Random.Range(0, tempos.Length)];
    }
    #region REFAZER_MELHOR
    private void SortearToupeiras(List<Toupeira> toupeiras, List<Armadilha> armadilhas)
    {
        toupeirasRaridade.Clear();

        int sorte = Random.Range(0, 24);

        switch (sorte)
        {
            case 0:
                //app.DebugFase("5%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 1)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                    /*
                    if (armadilhas[i].raridade == 1)
                    {
                        
                    }
                    */
                }
                break;

            case int n when n > 0 && n <= 3:
                //app.DebugFase("15%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 2)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 3 && n <= 7:
                //app.DebugFase("20%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 3)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 8 && n <= 12:
                //app.DebugFase("25%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 4)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;

            case int n when n > 12 && n <= 24:
                //app.DebugFase("60%");
                for (int i = 0; i < toupeiras.Count; i++)
                {
                    if (toupeiras[i].raridade == 5)
                    {
                        toupeirasRaridade.Add(toupeiras[i]);
                    }
                }
                break;
        }
    }
    #endregion

    public void SetFase(float batidasPorSegundo, float[] tempos)
    {
        this.batidasPorSegundo = batidasPorSegundo;
        timerInstanciasMax = 0;
        this.tempos = tempos;
    }
    public void CriarToupeiras(int maxToupeiras, int maxArmadilhas, List<GameObject> buracosDisponiveis, List<Toupeira> toupeiras, List<Armadilha> armadilhas, int bpm, AudioClip somAoSurgir, AudioClip somPancada, GameObject acertouEfeito)
    {
        SortearToupeiras(toupeiras, armadilhas);

        int maxInstancias = Random.Range(1, maxToupeiras);

        Utilidades.SortearLista(buracosDisponiveis);
        try
        {
            Toupeira toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];
            if (toupeira.comportamento == Comportamento.Lider)
            {
                buracosDisponiveis[Random.Range(0, buracosDisponiveis.Count)].GetComponent<Buraco>().CriarToupeira(toupeira.prefab,
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
                        buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.prefab,
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
                        buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.prefab,
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
          //  app.DebugFase("ERRO");
        }
    }

    private enum Estado
    {
        Rodando,
        CriarToupeiras,
        CriarArmadilhas
    }
}
