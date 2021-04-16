using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{   
    Collider col;
    public int hitPoints = 1;
    public int score = 1;
    [HideInInspector]public GameObject myParent;
    [HideInInspector]public Animator anim;

    void Start()
    {   
        anim = GetComponent<Animator>();

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

        if(hitPoints > 0)
        {
            col.enabled = true;
        }
        else
        {   
             myParent.GetComponent<HoleBehavior>().hasMole = false;
             ScoreManager.AddScore(score);

            Destroy(gameObject);
        }
       
    }
}
