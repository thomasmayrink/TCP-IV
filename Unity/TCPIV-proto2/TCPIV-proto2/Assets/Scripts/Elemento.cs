using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemento : MonoBehaviour
{
    public Aplicacao app 
    {
        get 
        {
            return GameObject.FindObjectOfType<Aplicacao>(); 
        } 
    }
}
