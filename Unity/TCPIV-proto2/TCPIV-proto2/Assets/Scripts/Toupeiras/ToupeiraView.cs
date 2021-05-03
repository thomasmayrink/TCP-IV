using System.Collections.Generic;
using UnityEngine;

public class ToupeiraView : MonoBehaviour
{
    private Animator animator;
    private ToupeiraEstados estadoAtual;
    private List<ToupeiraEstados> estadosPilha = new List<ToupeiraEstados>();

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        estadoAtual = ToupeiraEstados.SUBINDO;
    }

    private void Update()
    {
        switch (estadoAtual)
        {
            case ToupeiraEstados.SUBINDO:

                break;

            case ToupeiraEstados.ESPERANDO:

                break;

            case ToupeiraEstados.DESCENDO:

                break;
        }
    }

    private void Subir(Vector3 posicao)
    {
        if (animator)
            transform.position = posicao;
    }

    private void Esperar()
    {

    }

    private void Descendo()
    {

    }

    private void OnMouseDown()
    {
        animator.SetBool("Acertou", true);
    }
}
