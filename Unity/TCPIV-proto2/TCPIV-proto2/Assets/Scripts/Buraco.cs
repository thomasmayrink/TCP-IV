using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    [SerializeField] private GameObject[] toupeiras;

    void Start()
    {
        Instantiate(toupeiras[0], gameObject.transform.position + (Vector3.up * 2), Quaternion.identity);
    }
}
