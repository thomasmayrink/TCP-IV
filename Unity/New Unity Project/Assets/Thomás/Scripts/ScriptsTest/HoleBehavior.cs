#define GABRIEL
//#define THOMAS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if THOMAS
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

#elif GABRIEL
public class HoleBehavior : MonoBehaviour
{
    public GameObject[] moles;
    public bool hasMole;

    private float timer;

    void Start()
    {
        timer = 0;

        if (!hasMole)
        {
            Invoke("Spawn", Random.Range(0f, 7f)); ;
        }
    }

    private void Update()
    {
       /*
        * timer += Time.deltaTime;
        if (hasMole)
        {
            if (timer >= 6) foreach (GameObject go in moles) Destroy(go);
        }
       */
    }

    void Spawn()
    {
        if (!hasMole)
        {
            GameObject mole = Instantiate(moles[0], transform.position, Quaternion.identity) as GameObject;
            MoleBehavior moleB = mole.GetComponent<MoleBehavior>();
            moleB.myParent = this.gameObject;
            moleB.score = moleB.score * GameManager.curLevel;
            hasMole = true;
        }

        //Invoke("Spawn", Random.Range(7f, 7f)); ;
    }
}
#endif