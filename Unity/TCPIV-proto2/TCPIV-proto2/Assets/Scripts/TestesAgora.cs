using System.Collections.Generic;
using UnityEngine;

public class TestesAgora : Elemento
{
    [SerializeField] private Fase model;

    private float timer;
    private int timerMax;

    private void Start()
    {
        app.faseModel = model;
        app.faseController = this;

        timer = 0;
        timerMax = app.faseModel.Bpm / 60;

        app.faseModel.ToupeirasInstancias = new LinkedList<GameObject>();
        app.faseModel.ToupeiraBuraco = new List<KeyValuePair<int, GameObject>>();

        app.faseModel.QtdBuracosOcupados = 0;


    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            timer = 0;

            InstanciarToupeira();
            //DestruirToupeira();
        }
    }
    
    private void InstanciarToupeira()
    {
        int buracoId = Random.Range(0, app.faseModel.Buracos.Length);
        int toupeiraId = Random.Range(0, app.faseModel.Toupeiras.Length);

        if (app.faseModel.QtdBuracosOcupados < app.faseModel.Buracos.Length)
        {
            while (app.faseModel.Buracos[buracoId].GetComponent<Buraco>().EstaOcupado == true)
            {
                buracoId = Random.Range(0, app.faseModel.Buracos.Length);
            }
            app.faseModel.ToupeirasInstancias.AddLast(app.faseModel.Buracos[buracoId].GetComponent<Buraco>().CriarToupeira(app.faseModel.Toupeiras[toupeiraId].ToupeiraPrefab));
            app.faseModel.ToupeirasInstancias.Last.Value.GetComponent<ToupeiraController>().app.toupeiraModel = app.faseModel.Toupeiras[toupeiraId];
            app.faseModel.ToupeiraBuraco.Add(new KeyValuePair<int, GameObject>(buracoId, app.faseModel.ToupeirasInstancias.Last.Value));
            app.toupeiraModel = app.faseModel.ToupeirasInstancias.Last.Value.GetComponent<ToupeiraController>().app.toupeiraModel;
            app.toupeiraController = app.faseModel.ToupeirasInstancias.Last.Value.GetComponent<ToupeiraController>();
            app.toupeiraView = app.faseModel.ToupeirasInstancias.Last.Value.GetComponentInChildren<ToupeiraView>();
            app.faseModel.QtdBuracosOcupados++;
        }
        else
        {
            Debug.Log("<color=red>TODOS OS BURACOS OCUPADOS!</color>");
        }
    }

    private void DestruirToupeira()
    {
        foreach(GameObject t in app.faseModel.ToupeirasInstancias)
        {
            if (t.GetComponent<ToupeiraController>().app.toupeiraModel.DeveSerDestruida)
            {
                foreach(KeyValuePair<int, GameObject> kvp in app.faseModel.ToupeiraBuraco)
                {
                    if (kvp.Value == t)
                    {
                        app.faseModel.ToupeiraBuraco.Remove(kvp);
                    }
                }
                Destroy(t);
                app.faseModel.QtdBuracosOcupados--;
            }
        }
    }
}
