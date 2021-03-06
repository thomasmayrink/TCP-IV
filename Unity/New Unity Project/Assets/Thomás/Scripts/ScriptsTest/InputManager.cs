//#define GABRIEL
#define THOMAS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if THOMAS
public class InputManager : MonoBehaviour
{
    public GameObject fx_Punch;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.tag == "Mole")
                {
                    Instantiate(fx_Punch, hit.point, Quaternion.identity);
                    
                    MoleBehavior mole = hit.collider.gameObject.GetComponent<MoleBehavior>();
                    mole.SwitchCollider(0);
                    mole.anim.SetTrigger("hit");
                    //Debug.Log(hit.collider.gameObject + " got hit");    
                }
                
            }
        }
    }
}

#elif GABRIEL
public class InputManager : MonoBehaviour
{

}

#endif