using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toupeira : MonoBehaviour
{
    private Animator animator;
    private float velocidade { get; set; }
    public bool encostouNoChao { get; set; }
    public bool podeSerAcertado { get; private set; }
    public bool acertou { get; private set; }

    private int dancaId;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        podeSerAcertado = false;
        acertou = false;
        encostouNoChao = false;

        if (velocidade <= 0)
        {
            velocidade = 2f;
        }
    }

    void Update()
    {
        if (!acertou &&
            !podeSerAcertado &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("Subindo"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f)
            {
                podeSerAcertado = true;
                dancaId = Random.Range(1, 3);
                animator.SetInteger("DancaId", dancaId);
                velocidade = 0;
            }
            else
            {
                transform.position += velocidade * transform.up * Time.deltaTime;
            }
        }

        if (acertou)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Descendo"))
            {
                velocidade = 10;
                transform.position -= velocidade * transform.up * Time.deltaTime;
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    encostouNoChao = true;
                }
            }
        }
    }

    void ComportamentoNormal()
    {

    }

    private void OnMouseDown()
    {
        if (podeSerAcertado)
        {
            AcertarInimigo();
        }
    }

    private void AcertarInimigo()
    {
        podeSerAcertado = false;
        acertou = true;
        animator.SetBool("FoiAcertado", acertou);
        animator.SetBool("PodeSerAcertado", podeSerAcertado);
    }

    private void OnMouseUp()
    {
    }
}
