using UnityEngine;
using UnityEngine.UI;

public class Fase01 : MonoBehaviour
{
    [SerializeField] private Text txtVidas;
    private int vidas;
    [SerializeField] private Text txtPontos;
    private int pontos;

    private static Vector3 DISTANCIA = new Vector3(4f, 2f, 5f);

    private int MAX_INIMIGOS_AO_MESMO_TEMPO = 1;
    private const int MAX_BURACOS = 9;
    
    [SerializeField] private GameObject inimigoPrefab;
    private GameObject[] inimigos;
    private int inimigosEmCena;

    public Vector3[] posIniciais { get; private set; }

    private int posId;

    private bool podeCriarInimigo;

    void Start()
    {
        pontos = 0;
        vidas = 10;
        
        txtPontos.text = "Acertos: " + pontos;
        txtVidas.text = "Vidas: " + vidas;

        inimigos = new GameObject[MAX_INIMIGOS_AO_MESMO_TEMPO];
        inimigosEmCena = 0;
        DefinirPosicoesIniciais();
        CriarInimigo();
    }

    void Update()
    {
        if (vidas > 0)
        {
            foreach (GameObject go in inimigos)
            {
                if (go != null)
                {
                    if (go.GetComponent<Toupeira>().acertou)
                    {
                        pontos += (int)Time.deltaTime;
                        txtPontos.text = "Acertos: " + pontos / 10; 
                    }

                    if (go.GetComponent<Toupeira>().encostouNoChao)
                    {
                        if (go.GetComponent<Toupeira>().podeSerAcertado)
                        {
                            vidas--;
                            txtVidas.text = "Vidas: " + vidas;
                        }

                        Destroy(go);
                        inimigosEmCena--;
                        podeCriarInimigo = true;
                    }
                }
            }
            if (podeCriarInimigo) CriarInimigo();
        }
        else
        {
            foreach (GameObject go in inimigos)
            {
                try
                {
                    Destroy(go);
                } catch { }
            }
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
        int max = MAX_INIMIGOS_AO_MESMO_TEMPO - inimigosEmCena;
        
        int qtd = Random.Range(1, max);

        for (int i = 0; i < qtd; i++)
        {
            inimigos[i] = Instantiate(inimigoPrefab, PosicaoDisponivel(), Quaternion.identity);
            inimigosEmCena++;
        }

        podeCriarInimigo = false;
    }

    private Vector3 PosicaoDisponivel()
    {
        posId = Random.Range(0, MAX_BURACOS);

        for (int i = 0; i < inimigos.Length; i++)
        {
            if (inimigos[i] != null)
            {
                while (inimigos[i].transform.position.x == posIniciais[posId].x &&
                       inimigos[i].transform.position.z == posIniciais[posId].z)
                {
                    posId = Random.Range(0, MAX_BURACOS);
                }
            }
        }

        return posIniciais[posId];
    }
}
