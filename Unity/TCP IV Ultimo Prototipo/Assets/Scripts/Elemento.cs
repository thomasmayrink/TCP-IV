using UnityEngine;

public abstract class Elemento : MonoBehaviour
{
    public static Aplicacao app 
    { 
        get 
        {
            return GameObject.FindObjectOfType<Aplicacao>();
        } 
    }
}
