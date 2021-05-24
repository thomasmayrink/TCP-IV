using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteSom : MonoBehaviour
{
    public bool booleano;

    public AudioClip clip;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (booleano)
        {
            source.clip = clip;
            source.Play();
        }
        else
        {
            source.Play();
        }
    }
}