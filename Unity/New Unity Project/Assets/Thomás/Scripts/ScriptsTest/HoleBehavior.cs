using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehavior : MonoBehaviour
{   
    public GameObject[] moles;
    public bool hasMole;
    
    void Start()
    {
                
        if(!hasMole)
        {
            Invoke("Spawn", Random.Range(0f,7f));;    
        }
        
    }

   
    void Spawn()
    {   
        if(!hasMole)
        {
            //int num = Random.Range(0, moles.Length);
            int num = CalculateRarity();

            GameObject mole = Instantiate(moles[num], transform.position,Quaternion.identity) as GameObject;
            MoleBehavior moleB = mole.GetComponent<MoleBehavior>();
            moleB.myParent = this.gameObject;
            moleB.score = moleB.score * GameManager.curLevel;
            hasMole = true;
        }
        
        Invoke("Spawn", Random.Range(3f,7f));;
    }

    int CalculateRarity()
    {
       int num = Random.Range(1, 101);     

       if(num<=1)
       {
           return 4;
       } 
       else if (num <= 5)
       {
           return 3;
       }
       else if (num <= 20)
       {
           return 2;
       }
       else if(num <= 50)
       {
           return 1;
       }
        return 0;
    }    
}
