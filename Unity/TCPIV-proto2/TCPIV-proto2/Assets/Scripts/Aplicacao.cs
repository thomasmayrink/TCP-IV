using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplicacao : MonoBehaviour
{ 
    public Fase faseModel { get; set; }
    //public FaseController faseController;
    public TestesAgora faseController { get; set; }

    public Toupeira toupeiraModel { get; set; }
    public ToupeiraView toupeiraView { get; set; }
    public ToupeiraController toupeiraController { get; set; }

    public Buraco buraco { get; set; }
}
