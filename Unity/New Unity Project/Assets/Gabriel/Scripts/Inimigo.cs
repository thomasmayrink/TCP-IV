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
    public bool acertou { get; private set; }

    void Start()
    {
        podeSerAcertado = true;

        posYMin = transform.position.y;
        posYMax = posYMin + 3.6f;

        if (velocidade <= 0)
        {
            velocidade = 5f;
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
            transform.position = new Vector3(transform.position.x, posYMax, transform.position.z);

            velocidade *= -1;
        }
        else if(transform.position.y < posYMin)
        {
            encostouNoChao = true;
        }

        transform.position += velocidade * transform.up * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        if (podeSerAcertado)
        {
            AcertarInimigo();
           // acertou = false;
        }
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
        acertou = true;
    }

    private void OnMouseUp()
    {
        GetComponent<Renderer>().material = material;
    }
}
