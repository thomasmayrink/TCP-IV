using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase01 : MonoBehaviour
{
    private const int MAX_INIMIGOS = 3;
    private const int MAX_BURACOS = 9;

    [SerializeField] private GameObject fundo;
    
    [SerializeField] private GameObject inimigoPrefab;
    private int inimigoId;
    private GameObject inimigo;

    [SerializeField] private GameObject mascara;
    private GameObject mascaraInstancia;

    [SerializeField] private GameObject buraco;    

    public Vector3[] posIniciais { get; private set; }
    private int posId;

    void Start()
    {
        DefinirPosicoesIniciais();
        InstanciarCenario();
        CriarInimigo();
    }

    void Update()
    {
        if (inimigo.GetComponent<Inimigo>().encostouNoChao)
        {
            Debug.Log("foi");
            CriarInimigo();
        }
    }

    void DefinirPosicoesIniciais()
    {
        posIniciais = new Vector3[MAX_BURACOS];

        posIniciais[0] = new Vector3(1.8f, 0f, 0f);
        posIniciais[1] = new Vector3(0f, 0f, 0f);
        posIniciais[2] = new Vector3(-1.8f, 0f, 0f);
        posIniciais[3] = new Vector3(1.8f, -2.2f, 0f);
        posIniciais[4] = new Vector3(0f, -2.2f, 0f);
        posIniciais[5] = new Vector3(-1.8f, -2.2f, 0f);
        posIniciais[6] = new Vector3(1.8f, -4.4f, 0f);
        posIniciais[7] = new Vector3(0f, -4.4f, 0f);
        posIniciais[8] = new Vector3(-1.8f, -4.4f, 0f);
    }

    void InstanciarCenario()
    {
        Instantiate(fundo, Vector3.zero, Quaternion.identity);


        for (int i = 0; i < MAX_BURACOS; i++)
        {
            Instantiate(buraco, posIniciais[i], Quaternion.identity);
        }
    }

    void CriarInimigo()
    {
        try
        {
            inimigo.GetComponent<Inimigo>().encostouNoChao = false;
            Destroy(inimigo);
            Destroy(mascaraInstancia);
        } catch (Exception e)
        {
            Debug.Log("Exception: " + e);
        }

        inimigoId = UnityEngine.Random.Range(0, MAX_INIMIGOS) * 2;
        posId = UnityEngine.Random.Range(0, MAX_BURACOS);
        
        inimigo = Instantiate(inimigoPrefab, Vector3.down * 0.1f + posIniciais[posId], Quaternion.identity);
        inimigo.GetComponent<Inimigo>().spriteId = inimigoId;
        
        mascaraInstancia = Instantiate(mascara, posIniciais[posId], Quaternion.identity);
    }
}
