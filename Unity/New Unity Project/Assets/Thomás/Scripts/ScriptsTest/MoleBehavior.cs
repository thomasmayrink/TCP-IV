using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
    Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }
    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    public void NewEvent(int num)
    {
        col.enabled = (num == 0) ? false : true;

        

      // if(num == 0)
       // {
        //    col.enabled = false;
       // }
        //else
      //  {
        //    col.enabled = true;
       // }
    }



}
