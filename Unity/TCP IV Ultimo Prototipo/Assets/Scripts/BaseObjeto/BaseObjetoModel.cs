using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObjetoModel : Elemento
{ 
    public int Vida { get; set; }
    public int Pontos { get; set; }
    public int PontosPowerUp { get; set; }
    public float Velocidade { get; set; }
    public int Dano { get; set; }
    public int Raridade { get; set; }
    public float TemposNaTela { get; set; }
    public GameObject Prefab { get; set; }
}
