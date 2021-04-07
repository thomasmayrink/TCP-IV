using UnityEngine;
using UnityEngine.UI;

public class Fase01 : MonoBehaviour
{
    [SerializeField] private Text vidas;
    [SerializeField] private Text pontos;

    private static Vector3 DISTANCIA = new Vector3(4f, 2f, 5f);

    private const int MAX_INIMIGOS_AO_MESMO_TEMPO = 1;
    private const int MAX_BURACOS = 9;
    
    [SerializeField] private GameObject inimigoPrefab;
    private GameObject[] inimigos = new GameObject[MAX_INIMIGOS_AO_MESMO_TEMPO];
    private int inimigosEmCena;

    public Vector3[] posIniciais { get; private set; }

    private int posId;

    void Start()
    {
        inimigosEmCena = 0;
        DefinirPosicoesIniciais();
        CriarInimigo();
    }

    void Update()
    {
        try
        {
            foreach (GameObject go in inimigos)
            {
                if (go.GetComponent<Inimigo>().encostouNoChao)
                {
                    Destroy(go);
                    CriarInimigo();
                }
            }
        }
        catch { }
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
        int max = MAX_INIMIGOS_AO_MESMO_TEMPO - inimigosEmCena;
        
        int qtd = Random.Range(1, inimigos.Length);

        for (int i = 0; i < qtd; i++)
        {
            inimigos[i] = Instantiate(inimigoPrefab, PosicaoDisponivel(), Quaternion.identity);
        }

        /*
        for (int i = 0; i < qtd; i++)
        {
            for (int j = 0; j < inimigos.Length; j++)
            {
                if (inimigos[j] == null) break;
            }
        }

        int id = Random.Range(0, MAX_INIMIGOS_AO_MESMO_TEMPO);

        
        inimigo[0] = Instantiate(inimigoPrefab, Vector3.down * 0.1f + posIniciais[posId], Quaternion.identity);
        */

        inimigosEmCena++;
    }

    private Vector3 PosicaoDisponivel()
    {
        posId = Random.Range(0, MAX_BURACOS);

        for (int i = 0; i < posIniciais.Length; i++)
        {
            if (posIniciais[i] == posIniciais[posId])
            {
                //checar se tem alguém lá
                for (int j = 0; j < inimigos.Length; j++)
                {
                    if (inimigos[j] != null)
                    {
                    }
                }
            }
        }

        return posIniciais[posId];
    }
}
