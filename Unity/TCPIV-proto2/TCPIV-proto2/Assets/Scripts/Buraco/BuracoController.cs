using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoController : MonoBehaviour
{
    [SerializeField] Toupeira[] toupeiras;
    GameObject[] ts;

    private void Start()
    {
        ts = new GameObject[toupeiras.Length];

        for (int i = 0; i < toupeiras.Length; i++) 
        { 
            ts[i] = Instantiate(toupeiras[i].ToupeiraPrefab, new Vector3(0, -2.5f, 0), Quaternion.identity);
        }
    }

    private void Update()
    {
        for (int i = 0; i < toupeiras.Length; i++)
        {
            if (ts[i].transform.position.y < 1.5f)
            {
                ts[i].transform.position += toupeiras[i].Velocidade * transform.up * Time.deltaTime;
            }
        }
    }
}
