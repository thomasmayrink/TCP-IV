using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToupeiraController : MonoBehaviour
{
    public Toupeira model { get; set; }
    public ToupeiraView view
    {
        set
        {
            model.ToupeiraPrefab.GetComponentInChildren<ToupeiraView>();
        }
    }

    private void Update()
    {
    }
}
