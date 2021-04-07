using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase01 : MonoBehaviour
{
    [SerializeField] private Text vidas;
    [SerializeField] private Text pontos;

    private static Vector3 DISTANCIA = new Vector3(4f, 2f, 5f);

    private const int MAX_INIMIGOS_AO_MESMO_TEMPO = 3;
    private const int MAX_BURACOS = 9;
    
    [SerializeField] private GameObject inimigoPrefab;
    private GameObject inimigo;
    private Inimigo inimigoScript;

    public Vector3[] posIniciais { get; private set; }

    private int posId;

    void Start()
    {
        DefinirPosicoesIniciais();
        CriarInimigo();
    }

    void Update()
    {
        if (inimigoScript.encostouNoChao)
        {
            //if (inimigo.GetComponent<Inimigo>().)
            CriarInimigo();
        }
    }

    void DefinirPosicoesIniciais()
    {
        posIniciais = new Vector3[MAX_BURACOS];

        posIniciais[0] = new Vector3(-DISTANCIA.x, DISTANCIA.y, DISTANCIA.z);
        posIniciais[1] = new Vector3(0, DISTANCIA.y, DISTANCIA.z);
        posIniciais[2] = DISTANCIA;
        posIniciais[3] = new Vector3(-DISTANCIA.x, 0, 0);
        posIniciais[4] = Vector3.zero;
        posIniciais[5] = new Vector3(DISTANCIA.x, 0, 0);
        posIniciais[6] = -DISTANCIA;
        posIniciais[7] = new Vector3(0, -DISTANCIA.y, -DISTANCIA.z);
        posIniciais[8] = new Vector3(DISTANCIA.x, -DISTANCIA.y, -DISTANCIA.z);
    }

    void CriarInimigo()
    {
        try
        {
            inimigo.GetComponent<Inimigo>().encostouNoChao = false;
            Destroy(inimigo);
        } 
        catch {}

        posId = UnityEngine.Random.Range(0, MAX_BURACOS);
        
        inimigo = Instantiate(inimigoPrefab, Vector3.down * 0.1f + posIniciais[posId], Quaternion.identity);
        inimigoScript = inimigo.GetComponent<Inimigo>();

        Debug.Log("PosicaoId: " + posId + " || Posicao: " + posIniciais[posId]);
    }
}
