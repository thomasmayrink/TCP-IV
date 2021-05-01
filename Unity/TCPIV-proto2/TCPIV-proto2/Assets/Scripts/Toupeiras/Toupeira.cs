using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toupeira : MonoBehaviour
{
    [SerializeField] private int QTD_DANCAS = 2;

    Animator animator;
    int vida;
    float velocidade;
    bool podeSerAcertado;
    bool foiAcertado;
    int dancaId;

    protected Vector3 posicao;
    protected float posYMax;
    private float timer = 0;

    public Toupeira (int vida, float velocidade)
    {
        this.vida = vida;
        this.velocidade = velocidade;
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        velocidade = 2f;
        podeSerAcertado = false;
        foiAcertado = false;
        dancaId = Random.Range(1, QTD_DANCAS + 1);

        Debug.Log("Quantidade de danças: " + QTD_DANCAS);
    }
}