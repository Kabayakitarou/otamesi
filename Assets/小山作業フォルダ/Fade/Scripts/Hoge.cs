using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoge : MonoBehaviour
{
   [SerializeField] Fade fade;
   private void Start ()
   {
    fade.FadeOut(1f);
   }
    
        
    
}
