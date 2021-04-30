using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    float timer;
    [SerializeField] private Material material;
    private Color cor;
    private bool podeUsar;
    GameObject[] holes;

    void Start()
    {
        holes = GameObject.FindGameObjectsWithTag("Hole");
        timer = 0;
        cor = new Color(0, 1, 0);
        material.color = cor;
        podeUsar = false;
    }

    void Update()
    {
        timer += Time.deltaTime * 0.0001f;

        if (cor.r < 1)
        {
            cor.r += timer;
            material.color = cor;
        }
        else if (!podeUsar)
        {
            podeUsar = true;
            material.color = Color.red;
        }
    }

    private void OnMouseDown()
    {
        if (podeUsar)
        {
            foreach(GameObject h in holes)
            {
                if (h.GetComponent<HoleBehavior>().hasMole)
                {
                    h.GetComponent<HoleBehavior>().mole.GetComponent<MoleBehavior>().GotHit(0);
                }
            }
            cor.r = 0;
            cor.g = 1;
            cor.b = 0;
            timer = 0;
            material.color = cor;
            podeUsar = false;
        }
    }
}
