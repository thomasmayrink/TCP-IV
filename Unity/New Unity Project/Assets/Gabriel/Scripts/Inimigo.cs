using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public int spriteId { get; set; }
    public float velocidade { get; set; }
    private float posYMax;
    private float posYMin;
    public bool encostouNoChao { get; set; }

    void Start()
    {       
        GetComponent<SpriteRenderer>().sprite = sprites[spriteId];
        posYMin = transform.position.y;
        posYMax = posYMin + 1.7f;

        if (velocidade <= 0)
        {
            velocidade = 1.5f;
        }
    }

    void Update()
    {
        SubindoEDescendo();
    }

    void SubindoEDescendo()
    {
        if (transform.position.y >= posYMax)
        {
            velocidade *= -1;
        } else if(transform.position.y < posYMin)
        {
            velocidade = 0;
            encostouNoChao = true;
        }

        transform.position += velocidade * transform.up * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[spriteId + 1];
        if (velocidade > 0)
        {
            velocidade *= -2;
        }
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[spriteId];
    }
}
