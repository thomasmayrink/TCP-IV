//#define GABRIEL
#define THOMAS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if THOMAS
public class MoleBehavior : MonoBehaviour
{   
    Collider col;
    public int hitPoints = 1;
    public int score = 1;
    [HideInInspector]public GameObject myParent;
    [HideInInspector]public Animator anim;

    public GameObject popupText;

    void Start()
    {   
        anim = GetComponentInChildren<Animator>();

        col = GetComponent<Collider>();
        col.enabled = false;
    }
    public void DestroyObj()
    {   
        myParent.GetComponent<HoleBehavior>().hasMole = false;
        Destroy(gameObject);
    }

    public void SwitchCollider(int num)
    {
        col.enabled = (num == 0) ? false : true;

        //if(num == 0)
       // {
       //     col.enabled = false;
      //  }
       // else
      //  {
      //      col.enabled = true;
      //  }
        
    }

    //FOR POINTS LATER ON
    public void GotHit()
    {
        hitPoints--;

        if (hitPoints > 0)
        {
            col.enabled = true;
        }
        else
        {
            myParent.GetComponent<HoleBehavior>().hasMole = false;
            ScoreManager.AddScore(score);

            GameObject pop = Instantiate(popupText) as GameObject;

            pop.transform.SetParent(UIManager.instance.transform, false);
            pop.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            PopupText popText = pop.GetComponent<PopupText>();
            popText.Showtext(score);

            Destroy(gameObject);
        }
    }
    public void GotHit(int hp)
    {
        hitPoints = hp;

        if (hitPoints > 0)
        {
            col.enabled = true;
        }
        else
        {
            myParent.GetComponent<HoleBehavior>().hasMole = false;
            ScoreManager.AddScore(score);

            GameObject pop = Instantiate(popupText) as GameObject;

            pop.transform.SetParent(UIManager.instance.transform, false);
            pop.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            PopupText popText = pop.GetComponent<PopupText>();
            popText.Showtext(score);

            Destroy(gameObject);
        }
    }
}
#elif GABRIEL
public class MoleBehavior : MonoBehaviour
{
    public int hitPoints = 1;
    public int score = 1;
    [HideInInspector] public GameObject myParent;
    [HideInInspector] public Animator anim;
    public GameObject fx_Punch;
    public float tempo;

    public bool foiAcertado { get; private set; }
    public bool podeSerAcertado { get; private set; }
    private float velocidade;

    private int dancaId;
    private const int MAX_DANCA = 2;
    private ANIMACOES estado;

    public GameObject popupText;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        foiAcertado = false;
        podeSerAcertado = false;
        dancaId = 0;
        estado = ANIMACOES.SUBINDO;
    }

    public void DestroyObj()
    {
        myParent.GetComponent<HoleBehavior>().hasMole = false;
        Destroy(gameObject);
    }

    private void Update()
    {
        /*
        if (!foiAcertado &&
            !podeSerAcertado &&
            anim.GetCurrentAnimatorStateInfo(0).IsName("Subindo"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f)
            {
                podeSerAcertado = true;
                dancaId = Random.Range(1, 3);
                anim.SetInteger("DancaId", dancaId);
                velocidade = 0;
            }
            else
            {
                transform.position += velocidade * transform.up * Time.deltaTime;
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Descendo") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f)
            {
                velocidade = -10;
                transform.position += velocidade * transform.up * Time.deltaTime;
                Destroy(gameObject);
            }
        }
        */
    }

    private void OnMouseDown()
    {
        Debug.Log("Game Obj " + gameObject);
        GotHit();
    }

    public void Subir()
    {

    }

    public void GotHit()
    {
        hitPoints--;
       
        myParent.GetComponent<HoleBehavior>().hasMole = false;
        ScoreManager.AddScore(score);
        
        GameObject pop = Instantiate(popupText) as GameObject;
        pop.transform.SetParent(UIManager.instance.transform, false);
        pop.transform.position = Camera.main.WorldToScreenPoint(transform.position);

        PopupText popText = pop.GetComponent<PopupText>();
        popText.Showtext(score);

        Instantiate(fx_Punch, this.transform.position, Quaternion.identity);
        anim.SetBool("FoiAcertado", true);

        foiAcertado = true;
    }

    private void UpdateEstado()
    {
        switch (estado)
        {
            case ANIMACOES.SUBINDO:
                velocidade = 1.5f;
                transform.position += velocidade * transform.up * Time.deltaTime;

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f)
                {
                    podeSerAcertado = true;
                    dancaId = Random.Range(1, MAX_DANCA + 1);
                    anim.SetInteger("DancaId", dancaId);
                    velocidade = 0;
                    estado = estado + dancaId;
                }
                break;

            case ANIMACOES.DANCA1:

                break;

            case ANIMACOES.DANCA2:
                break;

            case ANIMACOES.DESCENDO:
                transform.position -= 2f * transform.up * Time.deltaTime;
                break;

            case ANIMACOES.DANO:
                break;

        }
        Debug.Log("Id: " + (int)estado + " | Estado: " + estado);
    }

    private void MudarEstado()
    {

    }

    private enum ANIMACOES
    {
        SUBINDO,
        DANCA1,
        DANCA2,
        DANO,
        DESCENDO
    }
}

#endif
