using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private const float MAXTIMER = 0.25f;
    private bool encostouParede = false;
    private Vector3 direcao;
    private float distanciaY = 1f;
    private float velocidade = 1f;

    private GameObject[] limitesTela;

    private float timer;

    void Start()
    {
        direcao = Vector3.left;

        foreach (GameObject go in limitesTela)
        {
            Debug.Log(go);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= MAXTIMER)
        {
            if (encostouParede)
            {
                encostouParede = false;
                Descer();
            }

            timer = 0;
            MoverX();
        }

    }

    private void MoverX()
    {
        timer += Time.deltaTime;
        transform.position += direcao * velocidade;
    }

    private void Descer()
    {
        if (transform.position.x == limitesTela[0].transform.position.x + 1 ||
            transform.position.x == limitesTela[1].transform.position.x - 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - distanciaY, transform.position.z);
            velocidade *= -1;
        }
    }
}
