using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toupeira : MonoBehaviour
{
    private Animator animator;
    private float velocidade { get; set; }
    private float posYMin;
    public bool encostouNoChao { get; set; }
    public bool podeSerAcertado { get; private set; }
    public bool acertou { get; private set; }
    private float timer;

    private int dancaId;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        podeSerAcertado = false;
        acertou = false;

        posYMin = transform.position.y;

        timer = 0;

        if (velocidade <= 0)
        {
            velocidade = 5f;
        }
    }

    void Update()
    {
        if (!acertou && 
            !podeSerAcertado &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("Subindo") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            podeSerAcertado = true;
            dancaId = Random.Range(1, 3);
        }

        if (dancaId == 3)
        {

        }
        /*
        timer += Time.deltaTime;
        if (!acertou && !podeSerAcertado && timer >= 0.5f)
        {
            podeSerAcertado = true;
            timer = 0;
        }

       if (podeSerAcertado && timer >= 
            */
    }

    void ComportamentoNormal()
    {

    }

    /*
    void SubindoEDescendo()
    {
        if (transform.position.y >= posYMax)
        {
            transform.position = new Vector3(transform.position.x, posYMax, transform.position.z);

            velocidade *= -1;
        }
        else if (transform.position.y < posYMin)
        {
            encostouNoChao = true;
        }

        transform.position += velocidade * transform.up * Time.deltaTime;
    }
    */

    private void OnMouseDown()
    {
        if (podeSerAcertado)
        {
            AcertarInimigo();
        }
    }

    private void AcertarInimigo()
    {
        animator.SetInteger("Danca3Id", 0);
        podeSerAcertado = false;
        acertou = true;
        animator.SetBool("FoiAcertado", acertou);
        animator.SetBool("PodeSerAcertado", podeSerAcertado);
        timer = 0;
    }

    private void OnMouseUp()
    {
    }
}
