using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToupeiraController : Elemento
{
    public void OnAcertou()
    {
        app.toupeiraModel.FoiAcertada = true;
        Debug.Log("Acertou");
    }
}
