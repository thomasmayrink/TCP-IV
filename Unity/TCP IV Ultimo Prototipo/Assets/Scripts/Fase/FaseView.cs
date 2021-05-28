using UnityEngine;
using System.Collections.Generic;

public class FaseView : Elemento
{
    private static List<Toupeira> toupeirasRaridade;
    private static List<Armadilha> armadilhasRaridade;
    private int proporcao;

    //private float timerFase;
    private float timerInstancias;
    private float timerInstanciasMax;

    private float batidasPorSegundo;
    private float[] tempos;

    private Estado estado;

    private void Start()
    {
        toupeirasRaridade = new List<Toupeira>();
        armadilhasRaridade = new List<Armadilha>();

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
                    int i = Random.Range(0, proporcao + 1);
                    if (i < proporcao) 
                    {
                        app.Notificar(Notificacao.Fase.CriarToupeiras, this);
                    }
                    else
                    {
                        app.Notificar(Notificacao.Fase.CriarArmadilhas, this);
                    }
                    estado = Estado.Criando;
                }
                break;

            case Estado.Criando:
                SortearTempo();
                estado = Estado.Rodando;
                break;
        }
    }
    private float SortearTempo()
    {
        return timerInstanciasMax = tempos[Random.Range(0, tempos.Length)];
    }

    #region REFAZER_MELHOR

    private void SortearToupeiras(List<Toupeira> toupeiras)
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
    private void SortearArmadilhas(List<Armadilha> armadilhas)
    {
        armadilhasRaridade.Clear();

        int sorte = Random.Range(0, 24);

        switch (sorte)
        {
            case 0:
                //app.DebugFase("5%");
                for (int i = 0; i < armadilhas.Count; i++)
                {
                    if (armadilhas[i].raridade == 1)
                    {
                        armadilhasRaridade.Add(armadilhas[i]);
                    }
                }
                break;

            case int n when n > 0 && n <= 3:
                //app.DebugFase("15%");
                for (int i = 0; i < armadilhas.Count; i++)
                {
                    if (armadilhas[i].raridade == 2)
                    {
                        armadilhasRaridade.Add(armadilhas[i]);
                    }
                }
                break;

            case int n when n > 3 && n <= 7:
                //app.DebugFase("20%");
                for (int i = 0; i < armadilhas.Count; i++)
                {
                    if (armadilhas[i].raridade == 3)
                    {
                        armadilhasRaridade.Add(armadilhas[i]);
                    }
                }
                break;

            case int n when n > 8 && n <= 12:
                //app.DebugFase("25%");
                for (int i = 0; i < armadilhas.Count; i++)
                {
                    if (armadilhas[i].raridade == 4)
                    {
                        armadilhasRaridade.Add(armadilhas[i]);
                    }
                }
                break;

            case int n when n > 12 && n <= 24:
                //app.DebugFase("60%");
                for (int i = 0; i < armadilhas.Count; i++)
                {
                    if (armadilhas[i].raridade == 5)
                    {
                        armadilhasRaridade.Add(armadilhas[i]);
                    }
                }
                break;
        }
    }

    #endregion

    public void SetFase(float batidasPorSegundo, float[] tempos, int proporcao)
    {
        this.batidasPorSegundo = batidasPorSegundo;
        timerInstanciasMax = 0;
        this.tempos = tempos;
        this.proporcao = proporcao;
    }
    public void CriarToupeiras(int maxToupeiras, List<GameObject> buracosDisponiveis, List<Toupeira> toupeiras, float bpm, AudioClip somAoSurgir, AudioClip somPancada, AudioClip somDano, AudioClip somFugiu, GameObject acertouEfeito)
    {
        SortearToupeiras(toupeiras);

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
                                                                                                                   somDano,
                                                                                                                   somFugiu,
                                                                                                                   acertouEfeito);
            }
            else
            {
                if (maxInstancias <= buracosDisponiveis.Count)
                {
                    for (int i = 0; i < maxInstancias; i++)
                    {
                        SortearToupeiras(toupeiras);
                        toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];

                        while (toupeira.comportamento == Comportamento.Lider)
                        {
                            SortearToupeiras(toupeiras);
                            toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];
                        }

                        buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.prefab,
                                                                                   toupeira,
                                                                                   bpm,
                                                                                   somAoSurgir,
                                                                                   somPancada,
                                                                                   somDano,
                                                                                   somFugiu,
                                                                                   acertouEfeito);
                    }
                }
                else
                {
                    for (int i = 0; i < buracosDisponiveis.Count; i++)
                    {
                        SortearToupeiras(toupeiras);
                        toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];

                        while (toupeira.comportamento == Comportamento.Lider)
                        {
                            SortearToupeiras(toupeiras);
                            toupeira = toupeirasRaridade[Random.Range(0, toupeirasRaridade.Count)];
                        }

                        buracosDisponiveis[i].GetComponent<Buraco>().CriarToupeira(toupeira.prefab,
                                                                                   toupeira,
                                                                                   bpm,
                                                                                   somAoSurgir,
                                                                                   somPancada,
                                                                                   somDano,
                                                                                   somFugiu,
                                                                                   acertouEfeito);
                    }
                }
            }
        }
        catch { }
    }
    public void CriarArmadilhas(int maxArmadilhas, List<GameObject> buracosDisponiveis, List<Armadilha> armadilhas, float bpm, AudioClip somAoSurgir, AudioClip somPancada, AudioClip somDano, GameObject acertouEfeito)
    {
        SortearArmadilhas(armadilhas);

        int maxInstancias = Random.Range(1, maxArmadilhas);

        Utilidades.SortearLista(buracosDisponiveis);
        try
        {
            Armadilha armadilha = armadilhasRaridade[Random.Range(0, armadilhasRaridade.Count)];
            if (maxInstancias <= buracosDisponiveis.Count)
            {
                for (int i = 0; i < maxInstancias; i++)
                {
                    SortearArmadilhas(armadilhas);
                    armadilha = armadilhasRaridade[Random.Range(0, armadilhasRaridade.Count)];
                    buracosDisponiveis[i].GetComponent<Buraco>().CriarArmadilha(armadilha.prefab,
                                                                                armadilha,
                                                                                bpm,
                                                                                somAoSurgir,
                                                                                somPancada,
                                                                                somDano,
                                                                                acertouEfeito);
                }
            }
            else
            {
                for (int i = 0; i < buracosDisponiveis.Count; i++)
                {
                    SortearArmadilhas(armadilhas);
                    armadilha = armadilhasRaridade[Random.Range(0, armadilhasRaridade.Count)];
                    buracosDisponiveis[i].GetComponent<Buraco>().CriarArmadilha(armadilha.prefab,
                                                                                armadilha,
                                                                                bpm,
                                                                                somAoSurgir,
                                                                                somPancada,
                                                                                somDano,
                                                                                acertouEfeito);
                }
            }
        }
        catch { }
    }

    private enum Estado
    {
        Rodando,
        Criando
    }
}
