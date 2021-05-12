using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestesAgora : MonoBehaviour
{
    [SerializeField] private Fase fase;
    //private GameObject[] buracos;
    //private bool[] buracoOcupado;

    private List<GameObject> toupeirasInstancias = new List<GameObject>();

    private float timer;

    private void Start()
    {       
        timer = 0;
    }

    private void Update()
    {
        //Invoke("InstanciarToupeira", Random.Range(fase.IntervaloMinCriarToupeira, fase.IntervaloMaxCriarToupeira));

        timer += Time.deltaTime;

        if (timer >= Random.Range((float)fase.IntervaloMinCriarToupeira, (float)fase.IntervaloMaxCriarToupeira))
        {
            InstanciarToupeira();
            timer = 0;
        }
    }

    private void InstanciarToupeira()
    {
        int buracoId = Random.Range(0, fase.Buracos.Length);
        if (fase.BuracosOcupados[buracoId])
        {
            InstanciarToupeira();
        }
        else
        {
            toupeirasInstancias.Add(Instantiate(fase.Toupeiras[Random.Range(0, fase.Toupeiras.Length)].ToupeiraPrefab,
                                  fase.Buracos[buracoId].transform.position + new Vector3(0, -1.55f, 0),
                                  Quaternion.identity));
        }
    }

    private void DestruirToupeira()
    {
        foreach(GameObject t in toupeirasInstancias)
        {
            if (t.GetComponent<ToupeiraController>().model.DeveSerDestruida)
            {
                Destroy(t);
                toupeirasInstancias.Remove(t);
            }
        }
    }
}
