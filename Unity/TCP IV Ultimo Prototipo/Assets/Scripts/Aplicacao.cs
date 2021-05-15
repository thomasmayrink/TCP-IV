using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplicacao : MonoBehaviour
{
    public FaseModel faseModel { get; set; }

    private AudioSource musicaSource;
    private AudioClip musica;

    private void Start()
    {
        faseModel = GetComponentInChildren<FaseModel>();
        musicaSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        musica = faseModel.Musica;
        musicaSource.clip = musica;
        musicaSource.Play();
    }

    private Controller[] Controllers
    {
        get
        {
            return GameObject.FindObjectsOfType<Controller>();
        }
    }

    public void Notificar(string evento_caminho, Object alvo, params object[] dados)
    {
        Controller[] controllers = Controllers;
        foreach(Controller c in controllers)
        {
            c.OnNotificacao(evento_caminho, alvo, dados);
        }
    }

    public void DebugFase(string txt)
    {
        Debug.Log(Utilidades.DebugComCor("Fase: " + txt, "green"));
    }
    public void DebugToupeira(string txt)
    {
        Debug.Log(Utilidades.DebugComCor("Toupeira: " + txt, "yellow"));
    }
}
