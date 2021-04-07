using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Material material;
    private float velocidade { get; set; }
    private float posYMax;
    private float posYMin;
    public bool encostouNoChao { get; set; }
    public bool podeSerAcertado { get; private set; }

    void Start()
    {
        podeSerAcertado = true;

        posYMin = transform.position.y;
        posYMax = posYMin + 2f;

        if (velocidade <= 0)
        {
            velocidade = 3f;
        }
    }

    void Update()
    {
        SubindoEDescendo();
    }

    void SubindoEDescendo()
    {
        if (transform.position.y >= posYMax)
        {
            velocidade *= -1;
        }
        else if(transform.position.y < posYMin)
        {
            velocidade = 0;
            encostouNoChao = true;
        }

        transform.position += velocidade * transform.up * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        if (podeSerAcertado) AcertarInimigo();
    }

    private void AcertarInimigo()
    {
        GetComponent<Renderer>().material.color = new Color(0.9f, 0.1f, 0.1f);

        if (velocidade > 0)
        {
            velocidade *= -2;
        } else
        {
            velocidade *= 2;
        }
        podeSerAcertado = false;
    }

    private void OnMouseUp()
    {
        GetComponent<Renderer>().material = material;
    }
}
