using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    public Text popupText;
    Animator anim;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        AnimatorClipInfo[] info = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, info[0].clip.length);
        
    }

   public void Showtext(int amount)
   {
       popupText.text = (amount > 0) ? "+" + amount : amount.ToString();
   }
}
